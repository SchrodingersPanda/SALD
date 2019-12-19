using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SALD.Models
{
    public class Sala
    {
        [Required]
        public EnumHorario Horario { get; set; }
        [Required]
        public string NivelID { get; set; }
        [Required]
        public string ID { get; set; }
        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        [Display(Name = "Asistente")]
        public string Ast { get; set; }
        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        [Display(Name = "Docente")]
        public string Educ { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual Planificacion Planificacion { get; set; }       
        public virtual Nivel Nivel { get; set; }
    }

    public enum EnumHorario
    {
        Mañana,
        Tarde,
        Completa,
        Extension
    }

}