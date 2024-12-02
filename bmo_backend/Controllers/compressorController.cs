using Microsoft.AspNetCore.Mvc;
using bmo_backend.Data;
using bmo_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class CompressorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompressorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Compressor>> CreateMachine(Compressor compressor)
    {
        _context.Compressors.Add(compressor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateMachine), new { id = compressor.Id }, compressor);
    }
}
