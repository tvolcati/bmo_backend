using bmo_backend.Data;
using Microsoft.AspNetCore.Mvc;
using bmo_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class VibrationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VibrationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Vibration>> CreateVibration(Vibration vibration)
    {
        _context.Vibration.Add(vibration);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateVibration), new { id = vibration.Id_running }, vibration);
    }
}
