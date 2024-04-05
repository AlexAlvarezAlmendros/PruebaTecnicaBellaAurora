using GestionInventario.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.BBDD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {}

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relación uno a muchos entre Categoria y Producto
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            // Relación uno a muchos entre Producto y Transaccion
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Transacciones)
                .WithOne(t => t.Producto)
                .HasForeignKey(t => t.ProductoId);

            // Indice para el Nombre en la tabla Productos
            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre)
                .HasDatabaseName("Index_Nombre")
                .IsUnique(); // Nombres de productos unicos

            // Configurando propiedades adicionales
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            // Eliminación en cascada
            // Esto eliminará todos los productos relacionados cuando se elimine una categoría
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
