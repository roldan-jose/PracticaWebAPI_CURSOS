using PracticaWebAPI_CURSOS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class InscripcionCursoDTO
    {
        public int idEstudiante { get; set; }
        public string codigo { get; set; }
        public PeriodoModel idPeriodo { get; set; }
        public CursoModel idCurso { get; set; }
    }
}
