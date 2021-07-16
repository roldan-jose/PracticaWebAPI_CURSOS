using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class CursoModel
    {
        public CursoModel()
        {
            InscripcionCursos = new HashSet<InscripcionCursoModel>();
        }
        
        public int IdCurso { get; set; }
        [Required(ErrorMessage = "El código del curso es obligatorio.")]
        [StringLength(7, ErrorMessage = "El {0} debe ser mínimo de {2} caractéres y máximo de {2} caractéres.", MinimumLength = 7)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripción del curso es obligatorio.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<InscripcionCursoModel> InscripcionCursos { get; set; }
    }
}
