using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuertoDelValle.Models
{
    [Table("T_TipoEnvio")]
    public class TipoEnvio{
        
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("lugar")]  
        public String lugar {get; set;}
        
        [Required]
        [Column("precio")]
        public decimal precio {get; set;}



    }
}