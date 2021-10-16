using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuertoDelValle.Models
{
    [Table("T_Receta")]
    public class Receta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese Nombre de la receta")]
        [Display(Name="Nombre de la Receta")]
        [Column("NombreReceta")]
        public String NombreReceta { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese URL de la imagen")]
        [Display(Name="URL de la imagen")]
        [Column("urlImagen")]
        public String Imagen { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese descripción de la receta")]
        [Display(Name="Descripción de la receta")]
        [Column("DescripcionReceta")]
        public String DescripcionReceta { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese los ingredientes")]
        [Display(Name="Ingredientes")]
        [Column("Ingrediente")]
        public String Ingrediente { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la preparación")]
        [Display(Name="Preparación")]
        [Column("Preparacion")]
        public String Preparacion { get; set; }

        public List<Reseña> Reseñas { get; set; }
    }
}