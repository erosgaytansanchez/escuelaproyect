using System.ComponentModel.DataAnnotations;

namespace escuelaproyect.DTOs
{
    public class MateriaCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe de tener mas de {1} carácteres")]
        public string Nombre { get; set; }
    }
}
