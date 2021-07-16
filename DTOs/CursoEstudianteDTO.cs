using PracticaWebAPI_CURSOS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class CursoEstudianteDTO
    {
        public CursoModel CursoDto { get; set; }
        public DateTime FechaDto { get; set; }
    }
}
