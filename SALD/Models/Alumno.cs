using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SALD.Models
{
    public class Alumno
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

        [Display(Name ="Fecha de nacimiento")]
       
        public DateTime FechaNAc { get; set; }

        [StringLength(5000, MinimumLength = 2)]
        [Required]
        [Display(Name ="Hoja de vida")]
        public string HojaVida { get; set; }

        [Required]
        [Display(Name ="Apoderado/Adulto a cargo")]
        public string AdultoID { get; set; }
        public string NivelID { get; set; }


        public virtual Nivel Nivel { get; set; }
        public virtual Sala Salas { get; set; }
        public virtual ICollection<Adulto> Adultos { get; set; }
        
        
    }
}