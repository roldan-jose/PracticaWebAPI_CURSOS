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
    public class PeriodosController : ControllerBase
    {
        private readonly CursosContext Ccontext;

        public PeriodosController(CursosContext _Ccontext)
        {
            Ccontext = _Ccontext;
        }

        [HttpGet]
        public async Task<IEnumerable<PeriodoModel>> Get()
        {
            return await Ccontext.Periodos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var periodoN = await Ccontext.Periodos.FindAsync(id);
            if (periodoN == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"Curso '{id}' no encontrado."));
            }
            else
            {
                return Ok(periodoN);
            }
        }

        [HttpGet("activo")]
        public async Task<IActionResult> GetPeActivo()
        {
            var periodoAct = await Ccontext.Periodos.Where(x => x.Estado).OrderByDescending(z => z.Anio).FirstOrDefaultAsync();

            if (periodoAct == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, "No existe ningun periodo abierto"));
            }

            return Ok(periodoAct);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PeriodoModel periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorsHelp.ModelStateErrors(ModelState));
            }
            if (await Ccontext.Periodos.Where(x => x.Anio == periodo.Anio).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El año: '{periodo.Anio}' ya existe."));
            }
            if (await Ccontext.Periodos.Where(x => x.IdPeriodo == periodo.IdPeriodo).AnyAsync())
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, $"El ID: '{periodo.IdPeriodo}' ya existe."));
            }

            await Ccontext.Periodos.AddAsync(periodo);
            await Ccontext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = periodo.IdPeriodo }, periodo);
        }

        [HttpPatch("activar/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            using (var transaccions = await Ccontext.Database.BeginTransactionAsync())
            {
                try
                {

                    var periodoAc = await Ccontext.Periodos.FindAsync(id);

                    if (periodoAc == null)
                    {
                        return NotFound(ErrorsHelp.RespuestaHttp(404, $"No existe ningun periodo '{id}'"));
                    }

                    if (periodoAc.Estado)
                    {
                        await transaccions.RollbackAsync();
                        return BadRequest(ErrorsHelp.RespuestaHttp(400, "Actualmente el periodo se encuantra ACTIVO"));
                    }
                    else
                    {
                        var periodos = await Ccontext.Periodos.Where(x => x.IdPeriodo != id).ToListAsync();
                        periodos.ForEach(c => c.Estado = false);
                        periodoAc.Estado = true;
                        await Ccontext.SaveChangesAsync();
                        await transaccions.CommitAsync();

                        return Ok();
                    }
                }
                catch (DbUpdateConcurrencyException e)
                {
                    await transaccions.RollbackAsync();
                    return StatusCode(500, "Ha ocurrido un error en la base de datos.  " + e);
                }

            }
        }

        [HttpPatch("desactivar/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {

            var periodoAc = await Ccontext.Periodos.FindAsync(id);

            if (periodoAc == null)
            {
                return NotFound(ErrorsHelp.RespuestaHttp(404, $"No existe ningun periodo '{id}'"));
            }
            if (!periodoAc.Estado)
            {
                return BadRequest(ErrorsHelp.RespuestaHttp(400, "Actualmente el periodo se encuantra DESACTIVADO"));
            }
            else
            {
                periodoAc.Estado = false;
                await Ccontext.SaveChangesAsync();
                return Ok("Periodo desactivado correctamente");
            }

        }


    }
}
