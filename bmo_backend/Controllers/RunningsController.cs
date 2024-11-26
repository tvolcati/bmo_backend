using bmo_backend.Data;
using bmo_backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RunningsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RunningsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Runnings>> CreateRunning(Runnings running)
    {
        _context.Runnings.Add(running);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateRunning), new { id = running.Id }, running);
    }
}
