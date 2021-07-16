using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El Usuario es obligatorio.")]
        [Display(Name = "Nombre de usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }
        [Compare("Clave", ErrorMessage = "Las Contraseñas no coinciden, por favor verifica.")]
        [NotMapped]
        public string ConfirmClave{ get; set; }
        public string SAL { get; set; }
    }
}
