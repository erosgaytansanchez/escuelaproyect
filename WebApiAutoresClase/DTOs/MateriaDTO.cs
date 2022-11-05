using System.ComponentModel.DataAnnotations;

namespace escuelaproyect.DTOs
{
    public class MateriaDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 120)]
        public string Nombre { get; set; }
    }
}
