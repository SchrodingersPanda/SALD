using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SALD.Models
{
    public class Adulto
    {
        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Nombre { get; set; }

        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Apellido { get; set; }
  
        [RegularExpression(@"^\d{1,2}\d{3}\d{3}[-][0-9kK]{1}$", ErrorMessage = "Formato: 99999999-K")]
        [StringLength(10, MinimumLength = 9)]
        [Required]
        [Display(Name ="RUT")]
        public string ID { get; set; }

        [RegularExpression(@"^[0-9+]*$", ErrorMessage = "Ingrese un número válido")]
        [StringLength(12, MinimumLength = 8)]
        [Required]
        public string Telefono { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-.]+$", ErrorMessage = "Ingrese una dirección de correo válida")]
        [Required]
        public string Email { get; set; }       
        

        public string AlumnoID { get; set; }

        public virtual Alumno Alumno { get; set; }
    }
}