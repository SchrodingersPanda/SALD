using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SALD.Models
{
    public class Planificacion
    {
        [Required]
        [Display(Name ="ID de Planificación")]
        public string ID { get; set; }

        [Required]
       
        public DateTime Inicio { get; set; }

        [Required]        
        public DateTime Termino { get; set; }

        [RegularExpression("^[A-Za-zÑñáéíóúÁÉÍÓÚ -]*$", ErrorMessage = "Ingrese sólo texto")]
        [StringLength(45, MinimumLength = 2)]
        [Required]
        public string Encargado { get; set; }

        
        [Display(Name ="Objetivos\npropuestos")]
        public string Objetivos_prop { get; set; }

        [Display(Name = "Objetivos\ncumplidos")]
        public string Objetivos_cump { get; set; }

        
        [Display(Name = "Actividades\npropuestas")]
        public string Actividades_prop { get; set; }

        [Display(Name = "Actividades\ncumplidas")]
        public string Actividades_cump { get; set; }


        public string NivelID { get; set; }

        [Display(Name = "Sala")]
        public string SalaID { get; set; }
        [Display(Name = "Número de\nreunión")]
        public int NumeroR { get; set; }
        public string Novedades { get; set; }
        [Display(Name = "Lista de \napoderados")]
        public string ListaAp { get; set; }

        //[RegularExpression(@"^\d{1,2}\.\d{3}\.\d{3}[-][0-9kK]{1}$", ErrorMessage = "Formato: 99.999.999-K")]
        //[StringLength(12, MinimumLength = 11)]
        //[Required]
        //public string UsuarioID { get; set; }

        //public virtual Usuario Usuario { get; set; }
        public virtual Nivel Nivel { get; set; }
        public virtual ICollection<Sala> Salas { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
    }
}