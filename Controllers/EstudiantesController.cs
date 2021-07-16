using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI_CURSOS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_CURSO.CodeHelp;
using PracticaWebAPI_CURSOS.DTOs;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PracticaWebAPI_CURSOS.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly CursosContext Ccontext;
        private readonly IWebHostEnvironment host;
        private readonly HttpContext _http;

        public EstudiantesController(CursosContext _Ccontext, IWebHostEnvironment _host, IHttpContextAccessor contextAccessor)
        {
            Ccontext = _Ccontext;
            host = _host;
            _http = contextAccessor.HttpContext;
        }

        [HttpGet]
        public List<EstudianteDTO> GetAll()
        {
            return Ccontext.Estudiantes
                .Select(x => new EstudianteDTO
            {
                IdEstudiante = x.IdEstudiante,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                NombreApellido = x.NombreApellido,
                FechaNacimiento = x.FechaNacimiento,
                URLImagenEstudiante = $"{_http.Request.Scheme}://{_http.Request.Host}/img/{x.PhotoName}"
                }).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstudianteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var estudiante = await Ccontext.Estudiantes.Select(estudiante => new EstudianteDTO
            {
                IdEstudiante = estudiante.IdEstudiante,
                Codigo = estudiante.Codigo,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                NombreApellido = estudiante.NombreApellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                URLImagenEstudiante = $"{_http.Request.Scheme}://{_http.Request.Host}/img/{estudiante.PhotoName}"
            }).FirstOrDefaultAsync(x => x.IdEstudiante == id);

            if (estudiante is null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"Estudiante con ID: {estudiante.IdEstudiante} No encontrado."));
            }

            return Ok(estudiante);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EstudianteModel estudianteM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }
            else
            {
                if (await Ccontext.Estudiantes.Where(z => z.Codigo == estudianteM.Codigo).AnyAsync())
                {
                    return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código {estudianteM.Codigo} ya existe en la Base de Datos."));
                }

                var NuevoEstudiante = new EstudianteModel
                {
                    IdEstudiante = estudianteM.IdEstudiante,
                    Codigo = estudianteM.Codigo,
                    Nombre = estudianteM.Nombre,
                    Apellido = estudianteM.Apellido,
                    NombreApellido = estudianteM.NombreApellido,
                    FechaNacimiento = estudianteM.FechaNacimiento
                };

                if (estudianteM.ImagenEstudianteDto is not null)
                {
                    var filename = Path.GetRandomFileName();
                    var extension = Path.GetExtension(estudianteM.ImagenEstudianteDto.FileName);

                    NuevoEstudiante.PhotoName = $"{filename}{extension}";

                    var path = $"{host.WebRootPath}/img/{NuevoEstudiante.PhotoName}";

                    using var fileStream = System.IO.File.Create(path);

                    await estudianteM.ImagenEstudianteDto.CopyToAsync(fileStream);
                }

                await Ccontext.Estudiantes.AddAsync(NuevoEstudiante);
                await Ccontext.SaveChangesAsync();


                return Accepted();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] EstudianteModel estudianteM)
        {
            if (estudianteM.IdEstudiante == 0)
            {
                estudianteM.IdEstudiante = id;
            }
            if (estudianteM.IdEstudiante != id)
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, "Error al consultar"));
            }


            if (!await Ccontext.Estudiantes.Where(z => z.IdEstudiante == id).AsNoTracking().AnyAsync())
            {
                return NotFound();
            }

            if (await Ccontext.Estudiantes.Where(x => x.Codigo == estudianteM.Codigo && x.IdEstudiante != estudianteM.IdEstudiante).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código {estudianteM.Codigo} ya existe."));
            }

            Ccontext.Entry(estudianteM).State = EntityState.Modified;
            if (!TryValidateModel(estudianteM, nameof(estudianteM)))
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }

            var estudianteEdit = await Ccontext.Estudiantes.FindAsync(estudianteM.IdEstudiante);

            if (estudianteM.ImagenEstudianteDto is not null)
            {
                var filename = Path.GetRandomFileName();
                var extension = Path.GetExtension(estudianteM.ImagenEstudianteDto.FileName);

                estudianteEdit.PhotoName = $"{filename}{extension}";

                var path = $"{host.WebRootPath}/img/{estudianteEdit.PhotoName}";

                using var fileStream = System.IO.File.Create(path);

                await estudianteM.ImagenEstudianteDto.CopyToAsync(fileStream);
            }

            await Ccontext.SaveChangesAsync();
            return Accepted();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromQuery] string code)
        {

            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, "El código está vacio."));
            }


            var estudianteM = await Ccontext.Estudiantes.FindAsync(id);
            if (estudianteM == null)
            {
                return NotFound();
            }
            if (await Ccontext.Estudiantes.Where(x => x.Codigo == code && x.IdEstudiante != id).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El código {code} ya existe."));
            }

            estudianteM.Codigo = code;
            if (!TryValidateModel(estudianteM, nameof(estudianteM)))
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }
            await Ccontext.SaveChangesAsync();
            return StatusCode(200, estudianteM);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudianteM = await Ccontext.Estudiantes.FindAsync(id);
            if (estudianteM == null)
            {
                return NotFound();
            }

            Ccontext.Estudiantes.Remove(estudianteM);
            await Ccontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> PatchUpdate(int id, JsonPatchDocument<EstudianteModel> _estudiante)
        {
            var estudianteM = await Ccontext.Estudiantes.FindAsync(id);

            if (estudianteM == null)
            {
                NotFound();
            }
            _estudiante.ApplyTo(estudianteM, ModelState);
            if (!TryValidateModel(estudianteM, "EstudianteModel"))
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }
            await Ccontext.SaveChangesAsync();
            return Ok(estudianteM);

        }

        [HttpGet("matricula/{estudiante}")]
        public async Task<IActionResult> MatriculasInscripciones(int estudiante)
        {
            EstudiantesMtriculaInscripcionDTO Estudinte = await Ccontext.Estudiantes.Include("Matriculas.InscripcionCursos.PeriodoM")
                                                                .Include("Matriculas.InscripcionCursos.IdCursoNavigation")
                                                                .Where(c => c.IdEstudiante == estudiante)
                                                                .Select(d => new EstudiantesMtriculaInscripcionDTO()
                                                                {
                                                                    IdEstudiante = d.IdEstudiante,
                                                                    Codigo = d.Codigo,
                                                                    NombreCompleto = d.NombreApellido,
                                                                    FechaNa = d.FechaNacimiento,
                                                                    URLImagenEstudiante = $"{_http.Request.Scheme}://{_http.Request.Host.Value}/img/{d.PhotoName}",
                                                                    Matriculas = d.Matriculas.Select(e => new MatriculasDTO()
                                                                    {
                                                                        IdPeriodo = e.IdPeriodo,
                                                                        AnioPeriodo = e.Fecha
                                                                    }).ToList(),
                                                                    Inscripcion = d.Matriculas.SelectMany(f => f.InscripcionCursos)
                                                                    .Select(g => new InscripcionesCursosDTO()
                                                                    {
                                                                        IdEstudiante = g.IdEstudiante,
                                                                        Anio = g.PeriodoM.Anio,
                                                                        Codigo = g.IdCursoNavigation.Codigo,
                                                                        Descripcion = g.IdCursoNavigation.Descripcion
                                                                    }).ToList()
                                                                }).SingleOrDefaultAsync();

            return Ok(Estudinte);
        }
    }
}
