using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SALD.Models
{
    public class Nivel
    {
        [Display(Name = "Nombre\nde nivel")]
        public EnumNombre Nombre { get; set; }

        [Display(Name = "Nivel ID")]
        public string ID { get; set; }

        [Display(Name = "Edad de\ningreso")]
        public int RangoEdad { get; set; }

        [Display(Name = "Cantidad\nde alumnos")]
        public int CantAlumnos { get; set; }

        [Range(2000,2050, ErrorMessage ="Ingrese un año válido - AAAA")]
        [Required]
        public int Año { get; set; }

        public EnumPeriodo Periodo { get; set; }
        
        public virtual ICollection<Sala> Salas { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
    }

  
    public enum EnumNombre
    {
        Sala_cuna_menor,
        Sala_cuna_mayor,
        Medio_menor,
        Medio_mayor,
        Prekinder,
        Kinder
    }
    public enum EnumPeriodo
    {
        Primer_Trimestre,
        Segundo_Trimestre,
        Tercer_Trimestre
    }
}