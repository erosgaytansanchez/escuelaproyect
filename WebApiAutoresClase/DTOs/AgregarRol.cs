using System.ComponentModel.DataAnnotations;

namespace WebApiAutoresClase.DTOs
{
    public class AgregarRol
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
