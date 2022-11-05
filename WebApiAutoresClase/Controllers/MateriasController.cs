using AutoMapper;
using escuelaproyect.DTOs;
using escuelaproyect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutoresClase.Data;
using WebApiAutoresClase.DTOs;
using WebApiAutoresClase.Models;

namespace escuelaproyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MateriasController(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MateriaCreacionDTO MateriaCreacionDTO)
        {
            var existeAutor = await _context.materias.AnyAsync(x => x.Nombre == MateriaCreacionDTO.Nombre);
            if (existeAutor)
            {
                return BadRequest($"Autor {MateriaCreacionDTO.Nombre} duplicado");
            }
            var materia = _mapper.Map<materia>(MateriaCreacionDTO);
            _context.Add(materia);
            await _context.SaveChangesAsync();

            var MateriaDTO = _mapper.Map<MateriaDTO>(materia);
            return Ok(MateriaDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.materias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new materia { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(MateriaCreacionDTO materiaCreacionDTO, int id)
        {
            var existe = await _context.materias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            var materia = _mapper.Map<materia>(materiaCreacionDTO);
            materia.Id = id;
            _context.Update(materia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

