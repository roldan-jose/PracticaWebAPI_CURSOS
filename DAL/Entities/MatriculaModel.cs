using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class MatriculaModel
    {
        public MatriculaModel()
        {
            InscripcionCursos = new HashSet<InscripcionCursoModel>();
        }

        [Required(ErrorMessage = "El ID de estudiante es obligatorio para matricular")]
        [Display(Name = "Id Estudiante")]
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El ID del periodo es obligatorio para matricular")]
        [Display(Name = "Id Periodo")]
        public int IdPeriodo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual EstudianteModel IdEstudianteNavigation { get; set; }
        public virtual PeriodoModel IdPeriodoNavigation { get; set; }
        public virtual ICollection<InscripcionCursoModel> InscripcionCursos { get; set; }
    }
}
