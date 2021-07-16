using System;
using System.Collections.Generic;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class InscripcionCursoModel
    {
        public int IdEstudiante { get; set; }
        public int IdPeriodo { get; set; }
        public int IdCurso { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual MatriculaModel Id { get; set; }
        public virtual CursoModel IdCursoNavigation { get; set; }
        public virtual PeriodoModel PeriodoM { get; set; }
        public virtual EstudianteModel EstudianteM { get; set; }
    }
}
