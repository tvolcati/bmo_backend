using Microsoft.AspNetCore.Mvc;
using bmo_backend.Data;
using bmo_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class CompressorRunningController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompressorRunningController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<CompressorRunningController>> CreateMachine(CompressorRunning compressorRunning)
    {
        _context.CompressorRunnings.Add(compressorRunning);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateMachine), new { id = compressorRunning.RunningId }, compressorRunning);
    }
}
