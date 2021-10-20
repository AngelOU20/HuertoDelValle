using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
namespace HuertoDelValle.Models
{
    [Table("estados")]
    public class Estado
    {
      public int id {get; set;}

      public String descripcion {get; set;}

      public ICollection<Pedido> pedidos {get; set;}
   }  
    
}