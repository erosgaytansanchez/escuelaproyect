using WebApiAutoresClase.DTOs;

namespace escuelaproyect.DTOs
{
    public class ProfesorDTOConAlumnos : ProfesorDTO
    {
        public List<AlumnoDTO> Alumnos { get; set; }
    }
}
