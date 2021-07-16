using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class EstudianteModel
    {
        public EstudianteModel()
        {
            Matriculas = new HashSet<MatriculaModel>();
        }

        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El código del estudiante es obligatorio.")]
        [StringLength(8, ErrorMessage = "El {0} debe ser mínimo de {2} caractéres y máximo de {2} caractéres.", MinimumLength = 8)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre(s) del estudiante es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido paterno y materno son obligatorios.")]
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; }
        public string NombreApellido { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no valida, intenta 'año-mes-día' (0000-00-00).")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public string PhotoName { get; set; }
        [NotMapped]
        public IFormFile ImagenEstudianteDto { get; set; }
        //[NotMapped]
        //public string URLImagenEstudiantetoDto { get; set; }

        public virtual ICollection<MatriculaModel> Matriculas { get; set; }
    }
}
