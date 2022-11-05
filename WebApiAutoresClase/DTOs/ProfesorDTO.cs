using System.ComponentModel.DataAnnotations;

namespace WebApiAutoresClase.DTOs
{
    public class ProfesorDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 120)]
        public string Nombre { get; set; }
    }
}
