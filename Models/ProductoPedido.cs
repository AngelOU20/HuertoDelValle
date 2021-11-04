using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HuertoDelValle.Models
{

    [Table("T_pedido_producto")]
    public class ProductoPedido
    {

        [Key]
        [Column("numPedido")]
        public int pedidoId {get; set;}

        public Pedido pedido {get; set;}

        [Key]
        [Column("numProducto")]
        public int productoId {get; set;}

        public Producto producto {get; set;}

        [Column("subtotal")]
        public Decimal subtotal {get; set;}

        [Column("observaciones")]
        public String observaciones {get; set;}

        [Column("cantidad")]
        public int cantidad {get; set;}
    }
}