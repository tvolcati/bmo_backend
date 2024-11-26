using bmo_backend.Data;
using bmo_backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TemperatureController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TemperatureController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Temperature>> CreateTemperature(Temperature temperature)
    {
        _context.Temperature.Add(temperature);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateTemperature), new { id = temperature.Id }, temperature);
    }
}
