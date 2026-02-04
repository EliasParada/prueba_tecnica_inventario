using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockWebEliasParada.Models.Entities;

namespace StockWebEliasParada.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Electrodomestico> Electrodomesticos { get; set; }
        public DbSet<TipoCategoria> TipoCategorias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Electrodomestico>()
                .HasOne(e => e.TipoCategoria)
                .WithMany(t => t.Electrodomesticos)
                .HasForeignKey(e => e.TipoCategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Electrodomestico>()
                .HasOne(e => e.Sucursal)
                .WithMany(s => s.Electrodomesticos)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}