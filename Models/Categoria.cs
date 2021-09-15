using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuertoDelValle.Models
{
    [Table("T_Categoria")]
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese Nombre de la categoria")]
        [Display(Name="Nombre de la Categoria")]
        [Column("NombreCategoria")]
        public String NombreCategoria { get; set; }
        public String ImagenCategoria { get; set; }
        public ICollection<Producto> Productos { get; set; }

        
    }
}