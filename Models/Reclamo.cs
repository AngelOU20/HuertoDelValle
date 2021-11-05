using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuertoDelValle.Models
{
    [Table("T_Reclamo")]
    public class Reclamo
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese un Nombre")]
        [Column("nombre")]
        public string Nombre{get;set;}

        [Column("apellido")]
        public string Apellido{get;set;}

        [Required(ErrorMessage = "Por favor, ingrese un email")]
        [EmailAddress]
        [Column("email")]
        public string Email{get;set;}

        [Required(ErrorMessage = "Por favor, ingrese un número de teléfono")]
        [Display(Name="Teléfono")]
        [Column("telefono")]
        public string Telefono{get;set;}

        [Required(ErrorMessage = "Por favor, ingrese el mensaje")]
        [Display(Name="Mensaje")]
        [Column("mensaje")]
        public string Mensaje{get;set;}
    }
}