using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class PeriodoModel
    {
        public PeriodoModel()
        {
            Matriculas = new HashSet<MatriculaModel>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPeriodo { get; set; }
        [Required(ErrorMessage = "El Año es un campo obligatorio.")]
        [Display(Name = "Año")]
        public int Anio { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<MatriculaModel> Matriculas { get; set; }
    }
}
