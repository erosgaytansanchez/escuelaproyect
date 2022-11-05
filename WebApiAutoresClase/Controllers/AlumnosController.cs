using AutoMapper;
using escuelaproyect.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutoresClase.Data;
using WebApiAutoresClase.DTOs;
using WebApiAutoresClase.Models;

namespace WebApiAutoresClase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlumnosController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfesorCreacionDTO AlumnoCreacionDTO)
        {
            var existeAutor = await _context.Alumnos.AnyAsync(x => x.Nombre == AlumnoCreacionDTO.Nombre);
            if (existeAutor)
            {
                return BadRequest($"Alumno {AlumnoCreacionDTO.Nombre} duplicado");
            }
            var alumno = _mapper.Map<Profesor>(AlumnoCreacionDTO);
            _context.Add(alumno);
            await _context.SaveChangesAsync();

            var AlumnoDTO = _mapper.Map<AlumnoDTO>(alumno);
            return Ok(AlumnoDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Alumno { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("{id:int}", Name = "ObtenerAumno")]
        public async Task<ActionResult<AlumnoDTOConMateria>> Get(int id)
        {
            var alumno = await _context.Alumnos
                .Include(x => x.materias)
                .ThenInclude(x => x.Profesor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }
            return _mapper.Map<AlumnoDTOConMateria>(alumno);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(AlumnoCreacionDTO alumnoCreacionDTO, int id)
        {
            var existe = await _context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            var alumnos = _mapper.Map<Alumno>(alumnoCreacionDTO);
            alumnos.Id = id;
            _context.Update(alumnos);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
