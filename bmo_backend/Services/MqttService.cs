using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using HiveMQtt.MQTT5.Types;
using Microsoft.Extensions.Configuration;
using bmo_backend.Data;
using bmo_backend.Models;
using System.Text.Json;

public class MqttService
{
    private readonly HiveMQClient _client;
    private readonly ApplicationDbContext _context;
    private bool _isSubscribed;

    public MqttService(IConfiguration configuration, ApplicationDbContext context)
    {
        var hiveMqConfig = configuration.GetSection("HiveMQ");
        var host = hiveMqConfig["Host"] ?? throw new ArgumentNullException("Host configuration is missing");
        var portString = hiveMqConfig["Port"] ?? throw new ArgumentNullException("Port configuration is missing");
        if (!int.TryParse(portString, out var port))
        {
            throw new ArgumentException("Port configuration is invalid");
        }

        var options = new HiveMQClientOptions
        {
            Host = host,
            Port = port,
            UseTLS = true,
            UserName = hiveMqConfig["UserName"],
            Password = hiveMqConfig["Password"]
        };
        _client = new HiveMQClient(options);
        _context = context;
        _isSubscribed = false;
    }

    public async Task ConnectAsync()
    {
        try
        {
            var connectResult = await _client.ConnectAsync();
            if (_client.IsConnected())
            {
                Console.WriteLine("Conexão com o HiveMQ foi bem-sucedida!");
            }
            else
            {
                Console.WriteLine("Falha ao conectar.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar: {ex.Message}");
        }
    }

    public async Task PublishAsync(string topic, string message)
    {
        if (_client.IsConnected())
        {
            try
            {
                var publishResult = await _client.PublishAsync(topic, message);
                Console.WriteLine($"Mensagem publicada no tópico {topic}: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao publicar mensagem: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Cliente não está conectado.");
        }
    }

 public async Task SubscribeAsync(string topic)
{
    if (_client.IsConnected())
    {
        try
        {
            var subscribeResult = await _client.SubscribeAsync(topic);

            if (!_isSubscribed)
            {
                _client.OnMessageReceived += async (sender, args) =>
                {
                    var publishMessage = args.GetType().GetProperty("PublishMessage")?.GetValue(args) as MQTT5PublishMessage;
                    if (publishMessage != null)
                    {
                        var receivedTopic = publishMessage.Topic;
                        var payloadBytes = publishMessage.Payload;
                        string payload = payloadBytes != null ? System.Text.Encoding.UTF8.GetString(payloadBytes) : "Payload vazio";

                        Console.WriteLine($"Mensagem recebida no tópico {receivedTopic}: {payload}");

                        var messageData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(payload);
                        if (messageData != null && messageData.ContainsKey("id"))
                        {
                            long id = messageData["id"].GetInt64();

                            var machine = await _context.Machines.FindAsync(id);
                            if (machine == null)
                            {
                                var newMachine = new Machines
                                {
                                    Id = id,
                                    MaxTemperature = 80,
                                    MaxVibration = 60,
                                    NeedFix = false
                                };
                                _context.Machines.Add(newMachine);
                                await _context.SaveChangesAsync();
                                Console.WriteLine($"Novo registro de máquina criado com ID: {id}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Falha ao acessar o PublishMessage.");
                    }
                };
                _isSubscribed = true;
            }

            Console.WriteLine($"Inscrito no tópico {topic}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao se inscrever no tópico: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Cliente não está conectado.");
    }
}

}
