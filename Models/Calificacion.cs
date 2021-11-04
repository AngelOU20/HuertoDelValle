using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huerto_Del_valle.Models
{
      [Table("t_calificacion")]
    public class Calificacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int id { get; set; }

        [Display(Name="Calificación")] 
        public string calificacion{ get; set; }

        [Display(Name="Comentario")] 
        public string comentario{ get; set; } 

        public DateTime addDate { get; set; }
    }
}