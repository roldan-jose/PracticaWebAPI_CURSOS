using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class EstudiantesMtriculaInscripcionDTO
    {
        public int IdEstudiante { get; set; }
        public string Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNa { get; set; }
        [NotMapped]
        public string URLImagenEstudiante { get; set; }
        public List<MatriculasDTO> Matriculas { get; set; }
        public List<InscripcionesCursosDTO> Inscripcion { get; set; }
    }

    public class MatriculasDTO
    {
        public int IdPeriodo { get; set; }
        public DateTime? AnioPeriodo { get; set; }
    }

    public class InscripcionesCursosDTO
    {
        public int IdEstudiante { get; set; }
        public int Anio { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
