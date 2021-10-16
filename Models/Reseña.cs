using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HuertoDelValle.Models{

    [Table("T_Reseña")]
    public class Reseña{
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresa un comentario")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Ingresa una calificacion")]
        public int? Calificacion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        public Receta Receta { get; set; }
        public int RecetaId { get; set; }

        public IdentityUser User { get; set; }
        public int UserId { get; set; }

        public Reseña(){
            Fecha = DateTime.Now;
        }

    }
}