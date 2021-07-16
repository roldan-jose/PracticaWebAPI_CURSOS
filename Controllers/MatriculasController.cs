using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI_CURSOS.DAL.Entities;
using PracticaWebAPI_CURSOS.DTOs;
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
    public class MatriculasController : ControllerBase
    {
        private readonly CursosContext Ccontext;

        public MatriculasController(CursosContext _Ccontext)
        {
            Ccontext = _Ccontext;
        }

        [HttpGet]
        public async Task<List<MatriculaModel>> GetAll()
        {
            return await Ccontext.Matriculas.Include(x => x.IdEstudianteNavigation).Include(z => z.IdPeriodoNavigation).ToListAsync();
        }

        [HttpGet("{periodo}/{estudiante}")]
        public async Task<IActionResult> Get(int estudiante, int periodo)
        {
            var matr = await Ccontext.Matriculas.Include(x => x.IdPeriodoNavigation).Include(y => y.IdEstudianteNavigation).Where(z => z.IdEstudiante == estudiante && z.IdPeriodo == periodo).SingleOrDefaultAsync();

            if (matr == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"El estudiante con Id: '{estudiante}' no existe con el periodo: '{periodo}'"));
            }
            else
            {
                return Ok(matr);
            }

        }

        [HttpPost("{periodo}/{estudiante}")]
        public async Task<IActionResult> Post(int estudiante, int periodo)
        {
            var periodoA = await Ccontext.Periodos.AsNoTracking().Where(x => x.IdPeriodo == periodo).SingleOrDefaultAsync();

            if (periodoA == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"No existe ningun periodo con ID: '{periodo}'"));
            }
            if (!periodoA.Estado)
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, "El periodo se encuentra desactivado."));
            }

            var estudianteA = await Ccontext.Estudiantes.AsNoTracking().Where(x => x.IdEstudiante == estudiante).SingleOrDefaultAsync();

            if (estudianteA == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"No existe ningun estudiante con ID: '{estudiante}'"));
            }

            if (await Ccontext.Matriculas.Where(x => x.IdPeriodo == periodo && x.IdEstudiante == estudiante).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(404, $"El estudiante '{estudiante}' ya se encuentra matriculado en este periodo '{periodo}'"));
            }

            await Ccontext.AddAsync(new MatriculaModel()
            {
                IdPeriodo = periodo,
                IdEstudiante = estudiante,
                Fecha = DateTime.Now
            });

            await Ccontext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { periodo = periodo, estudiante = estudiante }, null);
        }

        [HttpDelete("{periodo}/{estudiante}")]
        public async Task<IActionResult> Delete(int estudiante, int periodo)
        {
            var Dmatr = await Ccontext.Matriculas.FindAsync(estudiante, periodo);

            if (Dmatr == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"No existe matricula alguna para el estudiante '{estudiante}'"));
            }
            if (!await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo && x.Estado).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El periodo '{periodo}' actualmente está desactivado, NO puede ELIMINAR esta matrícula"));
            }
            if (await Ccontext.InscripcionCursos.Where(x => x.IdPeriodo == periodo && x.IdEstudiante == estudiante).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"No se puede eliminar esta matricula, por que el estudiante con ID: '{estudiante}' se encuentra inscrito en un curso"));
            }

            Ccontext.Matriculas.Remove(Dmatr);
            await Ccontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("estudiante/{id}")]
        public async Task<IActionResult> MatriculasEstudiates(int id)
        {
            List<MatriculasEstudianteDTO> matriculas = await Ccontext.Matriculas
                                                       .Include(x => x.IdPeriodoNavigation)
                                                       .Include("InscripcionCursos.IdCursoNavigation")
                                                       .Where(y => y.IdEstudiante == id)
                                                       .Select(x=> new MatriculasEstudianteDTO()
                                                       {
                                                           PeriodoDto = x.IdPeriodoNavigation.Anio,
                                                           FechaDto = x.Fecha,
                                                           CursosListDto = x.InscripcionCursos.Select(y => new CursosMatricula()
                                                           {
                                                               CodigoDto = y.IdCursoNavigation.Codigo,
                                                               NombreDto = y.IdCursoNavigation.Descripcion
                                                           }).ToList() 
                                                       })
                                                       .ToListAsync();
            return Ok(matriculas);
        }

        [HttpGet("estudiantes/{periodo}")]
        public async Task<IActionResult> MatriculaEstudiantes(int periodo)
        {
            MatriculaModel matricula = await Ccontext.Matriculas
                                             .Include(x => x.IdPeriodoNavigation)
                                             .Where(x => x.IdPeriodo == periodo)
                                             .FirstOrDefaultAsync();

            if(matricula== null)
            {
                return Ok(new List<MatriculadosEstudiantesDTO>());
            }

            List<EstudiantesCursoDTO> estudiante = await Ccontext.Matriculas
                                                   .Include(x => x.IdEstudianteNavigation)
                                                   .Where(x => x.IdPeriodo == periodo)
                                                   .Select(x => new EstudiantesCursoDTO()
                                                   {
                                                       IdEstudianteDto = x.IdEstudianteNavigation.IdEstudiante,
                                                       CodigoDto = x.IdEstudianteNavigation.Codigo,
                                                       NombreCompletoDto = x.IdEstudianteNavigation.NombreApellido
                                                   }).ToListAsync();

            MatriculadosEstudiantesDTO Lista = new MatriculadosEstudiantesDTO()
            {
                IdPeriodoDto = matricula.IdPeriodo,
                AnioPeriodoDto = matricula.IdPeriodoNavigation.Anio,
                EstudiantesDto = estudiante
            };

            return Ok(Lista);   
        }
    }
}