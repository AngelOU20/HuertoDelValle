using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace HuertoDelValle.Models
{
    [Table("pedido")]
    public class Pedido
    {
            [Key]
            [Column("idPedido")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int idpedido {get; set;}

            [Column("fechapedido")]
            public DateTime fechapedido {get; set;}

            [Column("cantidad")]
            public int cantidad {get; set;}

            [Column("subtotal")]    
            public decimal total {get; set;}

            [Column("codcliente")]
            public String cliente {get; set;}

            [Column("envio")]
            public int? tipoenvioid {get; set;}
            
            public TipoEnvio tipoenvio {get; set;}

            [Column("direccion")]
            public string direccion {get; set;}

            public Estado estado {get; set;}
            [Column("estado")]
            public int? estadoid {get; set;}


    }
}