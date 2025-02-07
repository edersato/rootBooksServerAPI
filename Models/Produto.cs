using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rootBooks.Models
{
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }

        [Required]
        public string dscProduto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal vlrUnitario { get; set; }
    }
}
