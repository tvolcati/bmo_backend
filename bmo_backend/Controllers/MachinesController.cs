using Microsoft.AspNetCore.Mvc;
using bmo_backend.Data;
using bmo_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MachinesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Machines>> CreateMachine(Machines machine)
    {
        _context.Machines.Add(machine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateMachine), new { id = machine.Id }, machine);
    }
}
