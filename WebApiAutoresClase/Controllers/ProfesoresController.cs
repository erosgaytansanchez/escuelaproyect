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
    public class ProfesoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfesoresController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfesorCreacionDTO ProfesorCreacionDTO)
        {
            var existeAutor = await _context.Profesores.AnyAsync(x => x.Nombre == ProfesorCreacionDTO.Nombre);
            if (existeAutor)
            {
                return BadRequest($"Autor {ProfesorCreacionDTO.Nombre} duplicado");
            }
            var profesor = _mapper.Map<Profesor>(ProfesorCreacionDTO);
            _context.Add(profesor);
            await _context.SaveChangesAsync();

            var ProfesorDTO = _mapper.Map<ProfesorDTO>(profesor);
            return Ok(ProfesorDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Profesores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Profesor { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("{id:int}", Name = "ObtenerProfesor")]
        public async Task<ActionResult<ProfesorDTOConAlumnos>> Get(int id)
        {
            var profesor= await _context.Profesores
                .Include(x => x.materias) 
                .ThenInclude(x => x.Alumno) 
                .FirstOrDefaultAsync(x => x.Id == id);
            if ( profesor== null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfesorDTOConAlumnos>(profesor);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProfesorCreacionDTO profesorCreacionDTO, int id)
        {
            var existe = await _context.Profesores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            var profesor = _mapper.Map<Profesor>(profesorCreacionDTO);
            profesor.Id = id;
            _context.Update(profesor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
