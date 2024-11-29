using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ProductsRequest
    {
        public int IdProducto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal ValorUnitario { get; set; }
        public bool Estado { get; set; }
    }
}
