using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class MatriculasEstudianteDTO
    {
        public int PeriodoDto { get; set; }
        public DateTime? FechaDto { get; set;  }
        public List<CursosMatricula> CursosListDto { get; set; }

    }

    public class CursosMatricula
    {
        public string CodigoDto { get; set; }
        public string NombreDto { get; set; }
    }
}
