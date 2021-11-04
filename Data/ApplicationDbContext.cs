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
        public DbSet<Contacto> DataContacto { get; set; }
        public DbSet<Receta> DataReceta { get; set; }
        public DbSet<Reseña> DataReseña { get; set; }

        public DbSet<Pedido> DataPedido { get; set; }
        public DbSet<ProductoPedido> DataProductoPedido { get; set; }
        public DbSet<TipoEnvio> DataTipoEnvio { get; set; }
        public DbSet<Estado> DataEstado { get; set; }
        public DbSet<Calificacion> DataCalificacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<ProductoPedido>()
        .HasKey(c => new { c.pedidoId, c.productoId });

        
        }

    }

    
}
