using System.ComponentModel.DataAnnotations;

namespace rootBooks.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string nmCliente { get; set; }
        public string Cidade { get; set; }
    }
}
