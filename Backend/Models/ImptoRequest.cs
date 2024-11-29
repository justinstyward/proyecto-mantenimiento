using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ImptoRequest
    {
        public int IdImpto { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public decimal PorcentajeImpto { get; set; }
        public bool Estado { get; set; }
        public string Producto { get; set; }
    }
}
