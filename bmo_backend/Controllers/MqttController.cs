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
}
