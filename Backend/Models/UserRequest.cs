using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UserRequest
    {
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
