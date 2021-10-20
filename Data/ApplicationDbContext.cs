using System;
using System.Collections.Generic;
using System.Text;
using HuertoDelValle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HuertoDelValle.Data
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> DataCategoria { get; set; }
        public DbSet<Producto> DataProducto { get; set; }
        public DbSet<Proforma> DataProforma { get; set; }
        public DbSet<Contacto> DataContacto { get; set; }
        public DbSet<Receta> DataReceta { get; set; }
        public DbSet<Reseña> DataReseña { get; set; }
        public DbSet<Orden> DataOrden { get; set; }

        public DbSet<Envio> DataEnvio { get; set; }
        public DbSet<TipoEnvio> DataTipoEnvio { get; set; }
        public DbSet<Estado> DataEstado { get; set; }
        public DbSet<Pedido> DataPedido { get; set; }


    }

    
}
