using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SALD.Models
{
    public class Bitacora
    {
        [Required]
        [Display(Name ="Id de bitácora")]
        public string ID { get; set; }
        [Required]
        public string Novedades { get; set; }
        //[Required]
        //[Display(Name = "Sala")]
        //public string SalaID { get; set; }
        [Required]
        [Display(Name = "Planificación")]
        public string PlanificacionID { get; set; }
        //[Required]        
        public virtual Sala Sala { get; set; }
      
        public virtual Planificacion Planificacion { get; set; }
        

    }
}