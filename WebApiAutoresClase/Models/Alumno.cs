using escuelaproyect.Models;

namespace WebApiAutoresClase.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public List<materia> materias { get; set; }

    }
}
