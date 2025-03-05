using Bibloteca.Models.Domain;


using Microsoft.EntityFrameworkCore;

namespace Bibloteca.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Marca> Marcas { get; set; } // Agregado
        public DbSet<Coche> Coches { get; set; } // Agregado
        public DbSet<Noticia> Noticias { get; set; } // Agregado

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasKey(r => r.PkRol);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.FkRol);

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Admin"
                });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Emmanuel",
                    UserName = "Usuario1",
                    Password = "123",
                    FkRol = 1
                });

            // Agregar las relaciones para las nuevas entidades
            modelBuilder.Entity<Coche>()
                .HasOne(c => c.Marca)
                .WithMany()
                .HasForeignKey(c => c.MarcaId);

            modelBuilder.Entity<Noticia>()
                .HasOne(n => n.Coche)
                .WithMany()
                .HasForeignKey(n => n.CocheId);
        }
    }
}
