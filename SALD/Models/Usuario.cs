using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SALD.Models
{
    public class Usuario
    {
        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Nombre { get; set; }

        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Apellido { get; set; }

        [RegularExpression(@"^\d{1,2}\.\d{3}\.\d{3}[-][0-9kK]{1}$", ErrorMessage = "Formato: 99.999.999-K")]
        [StringLength(12, MinimumLength = 11)]
        [Required]
        public string Rut { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nombre de usuario debe tener al menos 5 letras o dígitos")]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Usrtype { get; set; }

        [StringLength(45, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}