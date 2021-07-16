using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreApellido{ get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [NotMapped]
        public string URLImagenEstudiante { get; set; }
    }
}
