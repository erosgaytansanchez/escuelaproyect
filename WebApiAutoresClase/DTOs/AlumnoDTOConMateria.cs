using WebApiAutoresClase.DTOs;

namespace escuelaproyect.DTOs
{
    public class AlumnoDTOConMateria : AlumnoDTO
    {
        public List<MateriaDTO> Materias { get; set; }
    }
}
