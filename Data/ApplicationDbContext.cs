using Microsoft.EntityFrameworkCore;
using rootBooks.Models;

namespace rootBooks.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes {  get; set; }
        public DbSet<Produto> Produtos {  get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}
