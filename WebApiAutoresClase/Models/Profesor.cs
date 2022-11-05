using escuelaproyect.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApiAutoresClase.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:20, ErrorMessage ="El campo {0} no debe de tener mas de {1} carácteres")]
        public string Nombre { get; set; }
        public List<materia> materias { get; set; }

    }
}
