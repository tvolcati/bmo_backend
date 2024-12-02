using Microsoft.AspNetCore.Mvc;
using bmo_backend.Data;
using bmo_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class PrensaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrensaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Prensa>> CreateMachine(Prensa prensa)
    {
        _context.Prensas.Add(prensa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateMachine), new { id = prensa.Id }, prensa);
    }
}
