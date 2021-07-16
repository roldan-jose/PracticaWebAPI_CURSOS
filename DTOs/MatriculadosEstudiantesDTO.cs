using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DTOs
{
    public class MatriculadosEstudiantesDTO
    {
        public int IdPeriodoDto { get; set; }
        public int AnioPeriodoDto { get; set; }
        public List<EstudiantesCursoDTO> EstudiantesDto { get; set; }
    }
}
