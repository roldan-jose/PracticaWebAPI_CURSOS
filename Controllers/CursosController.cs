using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI_CURSOS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_CURSO.CodeHelp;

namespace PracticaWebAPI_CURSOS.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CursosContext Ccontext;

        public CursosController(CursosContext _Ccontext)
        {
            Ccontext = _Ccontext;
        }

        [HttpGet]
        public async Task<IEnumerable<CursoModel>> GetAll()
        {
            return await Ccontext.Cursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cursoN = await Ccontext.Cursos.FindAsync(id);
            if (cursoN == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"Curso '{id}' no encontrado."));
            }
            else
            {
                return Ok(cursoN);
            }
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string busq, [FromQuery] bool? state)
        {

            if (!string.IsNullOrWhiteSpace(busq))
            {
                return Ok(await Ccontext.Cursos.Where(x => (x.Descripcion.Contains(busq) || x.Codigo.Contains(busq)) && x.Estado == (state == null ? x.Estado : state.Value)).ToListAsync());
            }
            else
            {
                return Ok(await Ccontext.Cursos.Where(x => x.Estado == (state == null ? x.Estado : state.Value)).ToListAsync());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CursoModel curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }
            if (await Ccontext.Cursos.Where(x=> x.IdCurso == curso.IdCurso).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El ID: {curso.IdCurso} ya existe."));
            }
            if (await Ccontext.Cursos.Where(x => x.Codigo == curso.Codigo).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código: {curso.Codigo} ya existe."));
            }
            curso.Estado = curso.Estado ?? true;
            await Ccontext.Cursos.AddAsync(curso);
            await Ccontext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = curso.IdCurso }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id ,[FromBody] CursoModel curso)
        {
            if(curso.IdCurso == 0)
            {
                curso.IdCurso = id;
            }

            if(curso.IdCurso != id)
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, "Error al enviar la petición"));
            }
            if (!await Ccontext.Cursos.Where(x => x.IdCurso == curso.IdCurso).AsNoTracking().AnyAsync())
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"El curso {curso.IdCurso} no existe"));
            }
            if (await Ccontext.Cursos.Where(x=> x.Codigo == curso.Codigo && x.IdCurso != curso.IdCurso).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código {curso.Codigo} ya existe"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }

            curso.Estado = curso.Estado ?? true;
            Ccontext.Entry(curso).State = EntityState.Modified;
            await Ccontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cursoE = await Ccontext.Cursos.Include(x => x.InscripcionCursos).Where(z => z.IdCurso == id).SingleOrDefaultAsync();

            if(cursoE == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"Curso '{id}' no encontrado"));
            }

            if (cursoE.InscripcionCursos.Count > 0)
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"No se puede eliminar el curso '{id}' porque depende de uno o más datos de inscripción"));
            }

            Ccontext.Cursos.Remove(cursoE);
            await Ccontext.SaveChangesAsync();
            return NoContent();

        }

    }
}
