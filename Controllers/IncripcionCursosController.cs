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
    public class IncripcionCursosController : ControllerBase
    {
        private readonly CursosContext Ccontext;

        public IncripcionCursosController(CursosContext _Ccontext)
        {
            Ccontext = _Ccontext;
        }

        [HttpGet]
        public async Task<List<InscripcionCursoDTO>> GetAll()
        {
            return await Ccontext.InscripcionCursos
                .Include(x => x.IdCursoNavigation).Include(y => y.Id.IdEstudianteNavigation).Include(z => z.PeriodoM)
                .Select(a => new InscripcionCursoDTO()
                {
                    idEstudiante = a.IdEstudiante,
                    codigo = a.IdCursoNavigation.Codigo,
                    idCurso = a.IdCursoNavigation,
                    idPeriodo = a.PeriodoM
                })
                .ToListAsync();
        }


        [HttpGet("{periodo}/{estudiante}")]
        public async Task<IActionResult> GetCursosEstudiantes(int periodo, int estudiante)
        {
            var Inscripciones = await Ccontext.InscripcionCursos
                .Where(x => x.IdPeriodo == periodo && x.IdEstudiante == estudiante)
            .Select(y => new CursoDTO()
            {
                codigo = y.IdCursoNavigation.Codigo,
                descripcion = y.IdCursoNavigation.Descripcion,
                fecha = y.Fecha.Value
            }).ToListAsync();
            if (!await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El periodo '{periodo}' se encuentra DESACTIVADO o NO EXISTE."));
            }
            var EstudianT = await Ccontext.Estudiantes.Where(x => x.IdEstudiante == estudiante).AsNoTracking().SingleOrDefaultAsync();
            if (EstudianT == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"El estudiante con ID: '{estudiante}'  NO EXISTE."));
            }

            if (Inscripciones == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, "No existen datos de inscripción"));
            }
            else
            {
                return Ok(Inscripciones);
            }

        }


        [HttpGet("{periodo}/{estudiante}/{curso}")]
        public async Task<IActionResult> Get(int periodo, int estudiante, string curso)
        {
            var inscripcion = await Ccontext.InscripcionCursos
                .Include(x => x.IdCursoNavigation).Include(y => y.Id.IdEstudianteNavigation).Include(z => z.PeriodoM)
                .Where(x => x.IdEstudiante == estudiante && x.IdCursoNavigation.Codigo == curso && x.IdPeriodo == periodo)
                .Select(a => new InscripcionCursoDTO()
                {
                    idEstudiante = a.IdEstudiante,
                    codigo = a.IdCursoNavigation.Codigo,
                    idCurso = a.IdCursoNavigation,
                    idPeriodo = a.PeriodoM
                }).SingleOrDefaultAsync();

            if (inscripcion == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"El curso '{curso}' no se encuentra inscrito"));
            }

            return Ok(inscripcion);
        }

        [HttpPost("{periodo}/{estudiante}/{curso}")]
        public async Task<IActionResult> Post(int periodo, int estudiante, string curso)
        {
            if (!await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El periodo '{periodo}' se encuentra DESACTIVADO o NO EXISTE."));
            }
            var EstudianT = await Ccontext.Estudiantes.Where(x => x.IdEstudiante == estudiante).AsNoTracking().SingleOrDefaultAsync();
            if (EstudianT == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"El estudiante con ID: '{estudiante}'  NO EXISTE."));
            }
            var Curso = await Ccontext.Cursos.Where(x => x.Codigo == curso).AsNoTracking().SingleOrDefaultAsync();
            if (Curso == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(400, $"El código '{curso}' del curso NO EXISTE."));
            }
            if (!await Ccontext.Matriculas.Where(x => x.IdEstudiante == estudiante && x.IdPeriodo == periodo).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El estudiante '{estudiante}' actualmente NO se encuentra MATRICULADO en el periodo '{periodo}'."));
            }
            if (await Ccontext.InscripcionCursos.Where(x => x.IdEstudiante == estudiante && x.IdCurso == Curso.IdCurso && x.IdPeriodo == periodo).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El curso {curso} ya se encuentra inscrito"));
            }

            await Ccontext.InscripcionCursos.AddAsync(new InscripcionCursoModel()
            {
                IdEstudiante = estudiante,
                IdCurso = Curso.IdCurso,
                IdPeriodo = periodo,
                Fecha = DateTime.Now
            });

            await Ccontext.SaveChangesAsync();
            var Inscripcion = new InscripcionCursoDTO()
            {
                idEstudiante = estudiante,
                codigo = EstudianT.Codigo,
                idCurso = Curso,
                idPeriodo = await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo).AsNoTracking().SingleOrDefaultAsync()
            };
            return CreatedAtAction(nameof(Get), new { periodo = periodo, estudiante = estudiante, curso = curso }, Inscripcion);
        }

        [HttpDelete("{periodo}/{estudiante}/{curso}")]
        public async Task<IActionResult> Delete(int periodo, int estudiante, string curso)
        {
            if (!await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo && x.Estado == true).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El periodo '{periodo}' se encuentra DESACTIVADO o NO EXISTE"));
            }   
            if (!await Ccontext.Estudiantes.Where(x => x.IdEstudiante == estudiante).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El estudiante con ID: '{estudiante}' NO EXISTE"));
            }
            if (!await Ccontext.Cursos.Where(x => x.Codigo == curso).AsNoTracking().AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código '{curso}' del curso NO EXISTE"));
            }

            int IdCursosE = await Ccontext.Cursos.Where(x => x.Codigo == curso).AsNoTracking().Select(y => y.IdCurso).FirstOrDefaultAsync();
            var inscripcion = await Ccontext.InscripcionCursos.FindAsync(estudiante, periodo, IdCursosE);

            if (inscripcion == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, "El curso no se enuentra inscrito"));
            }

            Ccontext.InscripcionCursos.Remove(inscripcion);
            await Ccontext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("estudiante/{periodo}/{curso}")]
        public async Task<IActionResult> InscripcionEstudiantes(int periodo, string curso)
        {
            List<EstudiantesCursoDTO> EstudiantesC = await Ccontext.InscripcionCursos
                                                    .Include(x => x.IdCursoNavigation)
                                                    .Include(x => x.EstudianteM)
                                                    .Where(x => x.IdPeriodo == periodo && x.IdCursoNavigation.Codigo == curso)
                                                    .Select(x => new EstudiantesCursoDTO()
                                                    {
                                                        IdEstudianteDto = x.IdEstudiante,
                                                        CodigoDto = x.EstudianteM.Codigo,
                                                        NombreCompletoDto = x.EstudianteM.NombreApellido
                                                    })
                                                    .ToListAsync();
            if (EstudiantesC == null)
            {
                NotFound("No hay nada");
            }
            return Ok(EstudiantesC);

        }
    }
}
