using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MqttController : ControllerBase
{
    private readonly MqttService _mqttService;

    public MqttController(MqttService mqttService)
    {
        _mqttService = mqttService;
    }

    [HttpGet("connect")]
    public async Task<IActionResult> Connect()
    {
        await _mqttService.ConnectAsync();
        return Ok("Conexão tentada. Verifique o console para o resultado.");
    }

    [HttpPost("publish")]
    public async Task<IActionResult> Publish([FromQuery] string topic, [FromQuery] string message)
    {
        await _mqttService.PublishAsync(topic, message);
        return Ok($"Mensagem publicada no tópico {topic}: {message}");
    }

    [HttpGet("subscribe")]
    public async Task<IActionResult> Subscribe([FromQuery] string topic)
    {
        await _mqttService.SubscribeAsync(topic);
        return Ok($"Inscrito no tópico {topic}");
    }
}
