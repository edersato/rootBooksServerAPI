using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rootBooks.Models
{
    public class Venda
    {
        [Key]
        public int idVenda { get; set; }

        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        public int idProduto { get; set; }
        public Produto? Produto { get; set; }

        public int qtdVenda { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; }

        public decimal ValorTotal => vlrUnitarioVenda * qtdVenda;
    }
}
