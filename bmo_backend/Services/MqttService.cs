using HiveMQtt.Client.Options;
using HiveMQtt.Client;

public class MqttService
{
    private readonly HiveMQClient _client;

    public MqttService(IConfiguration configuration)
    {
        var hiveMqConfig = configuration.GetSection("HiveMQ");
        var options = new HiveMQClientOptions
        {
            Host = hiveMqConfig["Host"],
            Port = int.Parse(hiveMqConfig["Port"]),
            UseTLS = true,
            UserName = hiveMqConfig["UserName"],
            Password = hiveMqConfig["Password"]
        };
        _client = new HiveMQClient(options);
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
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}

