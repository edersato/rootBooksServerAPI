using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rootBooks.Data;
using rootBooks.Models;

namespace rootBooks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClientesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        var clientes = await _context.Clientes.ToListAsync();

        if (clientes == null || clientes.Count == 0)
        {
            return NoContent(); // Retorna 204 se não há registros
        }

        return Ok(clientes);
    }

    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    // POST: api/Clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
    }

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Cliente clienteUpdated)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        cliente.nmCliente = clienteUpdated.nmCliente;
        cliente.Cidade = clienteUpdated.Cidade;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
