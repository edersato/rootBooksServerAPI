using Microsoft.AspNetCore.Mvc;
using rootBooks.Data;
using rootBooks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;

namespace rootBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> Get()
        {
            var vendas = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .ToListAsync();
            return Ok(vendas);
        }

        // GET: api/vendas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> Get(int id)
        {
            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(v => v.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        // POST: api/vendas
        [HttpPost]
        public async Task<ActionResult<Venda>> Post([FromBody] Venda venda)
        {
            if (venda == null)
            {
                return BadRequest("Venda não pode ser nula.");
            }

            if (venda.IdCliente <= 0 || venda.idProduto <= 0 || venda.qtdVenda <= 0 || venda.vlrUnitarioVenda <= 0)
            {
                return BadRequest("Campos inválidos.");
            }

            var cliente = await _context.Clientes.FindAsync(venda.IdCliente);
            if (cliente == null)
            {
                return BadRequest($"Cliente com ID {venda.IdCliente} não encontrado.");
            }

            var produto = await _context.Produtos.FindAsync(venda.idProduto);
            if (produto == null)
            {
                return BadRequest($"Produto com ID {venda.idProduto} não encontrado.");
            }

            venda.vlrUnitarioVenda = produto.vlrUnitario;
            venda.dthVenda = DateTime.UtcNow;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = venda.idVenda }, venda);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Venda vendaUpdated)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            venda.qtdVenda = vendaUpdated.qtdVenda;
            venda.dthVenda = vendaUpdated.dthVenda;

            var produto = await _context.Produtos.FindAsync(vendaUpdated.idProduto);
            if (produto == null)
            {
                return BadRequest("Produto não encontrado.");
            }

            venda.vlrUnitarioVenda = produto.vlrUnitario;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}