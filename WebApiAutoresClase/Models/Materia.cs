using WebApiAutoresClase.Models;

namespace escuelaproyect.Models
{
    public class materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int AlumnoId { get; set; }
        public int ProfesorId { get; set; }
        
        public Alumno Alumno { get; set; }
        public Profesor Profesor { get; set; }
    }
}
