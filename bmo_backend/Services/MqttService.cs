using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using HiveMQtt.MQTT5.Types;
using Microsoft.Extensions.Configuration;
using bmo_backend.Data;
using bmo_backend.Models;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

public class MqttService
{
    private readonly HiveMQClient _client;
    private readonly IServiceScopeFactory _scopeFactory;
    private bool _isSubscribed;

    public MqttService(IConfiguration configuration, IServiceScopeFactory scopeFactory)
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
        _scopeFactory = scopeFactory;
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
                Console.WriteLine($"{topic}");
                var subscribeResult = await _client.SubscribeAsync(topic);

                if (!_isSubscribed)
                {
                    _client.OnMessageReceived += async (sender, args) =>
                    {
                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                            var publishMessage = args.GetType().GetProperty("PublishMessage")?.GetValue(args) as MQTT5PublishMessage;
                            if (publishMessage != null)
                            {
                                var receivedTopic = publishMessage.Topic;
                                var payloadBytes = publishMessage.Payload;
                                string payload = payloadBytes != null ? System.Text.Encoding.UTF8.GetString(payloadBytes) : "Payload vazio";

                                Console.WriteLine($"Mensagem recebida no tópico {receivedTopic}: {payload}");

                                try
                                {
                                    var messageData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(payload);

                                    if (messageData != null && messageData.ContainsKey("machineType") && messageData.ContainsKey("id"))
                                    {
                                        string machineType = messageData["machineType"].GetString();
                                        int id = messageData["id"].GetInt32();

                                        if (machineType == "Prensa")
                                        {
                                            await HandlePrensaMessageAsync(_context, messageData, id);
                                        }
                                        else if (machineType == "Compressor")
                                        {
                                            await HandleCompressorMessageAsync(_context, messageData, id);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Tipo de máquina desconhecido: {machineType}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Mensagem inválida: faltando 'machineType' ou 'id'");
                                    }
                                }
                                catch (JsonException jsonEx)
                                {
                                    Console.WriteLine($"Erro ao deserializar a mensagem: {jsonEx.Message}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Falha ao acessar o PublishMessage.");
                            }
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

    private async Task HandlePrensaMessageAsync(ApplicationDbContext _context, Dictionary<string, JsonElement> messageData, int id)
    {
        var prensa = await _context.Prensas.FindAsync(id);
        if (prensa == null)
        {
            // Cria um novo registro de Prensa
            prensa = new Prensa
            {
                Id = id,
                NumberOfFailures = 0,
                MaximumDistance = 70,
                // Definir outras propriedades padrão aqui
            };
            _context.Prensas.Add(prensa);
            await _context.SaveChangesAsync();
            Console.WriteLine($"Nova Prensa criada com ID: {id}");
        }

        if (messageData.ContainsKey("oil_quality"))
        {
            prensa.OilQuality = messageData["oil_quality"].GetDouble().ToString();
            _context.Prensas.Update(prensa);
        }

        // Cria um novo registro de PrensaRunning
        var prensaRunning = new PrensaRunning
        {
            PrensaId = id,
            TimeStamp = DateTime.UtcNow,
        };

        if (messageData.ContainsKey("distance"))
        {
            prensaRunning.DistanceTraveled = messageData["distance"].GetDouble();
        }

        _context.PrensaRunnings.Add(prensaRunning);
        await _context.SaveChangesAsync();
        Console.WriteLine($"Novo registro de PrensaRunning criado para Prensa ID: {id}");
    }

    private async Task HandleCompressorMessageAsync(ApplicationDbContext _context, Dictionary<string, JsonElement> messageData, int id)
    {
        var compressor = await _context.Compressors.FindAsync(id);
        if (compressor == null)
        {
            // Cria um novo registro de Compressor
            compressor = new Compressor
            {
                Id = id,
                // Você pode definir outras propriedades padrão aqui, se necessário
            };
            _context.Compressors.Add(compressor);
            await _context.SaveChangesAsync();
            Console.WriteLine($"Novo Compressor criado com ID: {id}");
        }

        // Cria um novo registro de CompressorRunning
        var compressorRunning = new CompressorRunning
        {
            CompressorId = id,
            TimeStamp = DateTime.Now,
        };

        if (messageData.ContainsKey("temperature"))
        {
            compressorRunning.Temperature = messageData["temperature"].GetDouble();
        }
        if (messageData.ContainsKey("vibration"))
        {
            compressorRunning.Vibration = messageData["vibration"].GetDouble();
        }

        _context.CompressorRunnings.Add(compressorRunning);
        await _context.SaveChangesAsync();
        Console.WriteLine($"Novo registro de CompressorRunning criado para Compressor ID: {id}");
    }
}
