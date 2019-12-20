using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
        
        [RegularExpression(@"^\d{1,2}\d{3}\d{3}[-][0-9kK]{1}$", ErrorMessage = "Formato: 99999999-K")]
        [StringLength(10, MinimumLength = 9)]
        [Display(Name ="RUT")]
        [Required]
        public string ID { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nombre de usuario debe tener al menos 5 letras o dígitos")]
        [Required]
        public string Username { get; set; }

        [Display (Name ="Tipo de Usuario")]        
        [Required]
        public EnumType Usrtype { get; set; }

        [StringLength(45, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Planificacion> Planificaciones { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
    }

    public enum EnumType
    {
        Sysadmin,
        Dirección,
        Docente,
        Asistente,
        Fonoaudiología
    }
    
}