using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ClientsRequest
    {
        public int IdCliente { get; set; }
        [Required]
        public string Nit { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
