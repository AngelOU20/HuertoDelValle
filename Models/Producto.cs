using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace HuertoDelValle.Models
{
    [Table("T_Producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese Nombre del producto")]
        [Display(Name="Nombre del Producto")]
        [Column("NombreProducto")]
        public String NombreProducto { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la URL de la imagen del producto")]
        [Display(Name="Imagen del producto")]
        [Column("ImagenProducto")]
        public String ImagenProducto { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la descripción del producto")]
        [Display(Name="Descripción del producto")]
        [Column("DescripcionProducto")]
        public String DescripcionProducto { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el precio del producto")]
        [Display(Name="Precio")]
        [Column("PrecioProducto")]
        public decimal PrecioProducto { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el stock del producto")]
        [Display(Name="Stock")]
        [Column("Stock")]
        public int Stock { get; set; }

        public Categoria Categoria { get; set; }

        // EF - Shadow Property

        [Column("CategoriaId")]
        public int CategoriaId { get; set; }
    }
}