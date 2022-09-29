using Libreria.Domain;
using Libreria.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infrastructure.Persistence
{

    public class LibreriaDbContext : DbContext
    {

        //private const string conexion = @"Data Source = RICHI-PC;Initial Catalog=Streamer;Integrated Security=true";

        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options)
        {
        }

        public DbSet<Libro>? Libros { get; set; }
        public DbSet<Editorial>? Editoriales { get; set; }
        public DbSet<Genero>? Generos { get; set; }
        public DbSet<Autor>? Autores { get; set; }


        // Se ejecuta antes de insertar/actualizar el valor en la BD para la auditoria
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // recorre todas las entidades antes de realizar la inserccion apuntando a la entidad Base
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// usar para hacer la relacion logica entre entidades en el caso que no se hayan declarado en el DOMAIN como estan ahora
            /// relacion logica por codigo
            /// 

            modelBuilder.Entity<Libro>()
                .HasOne(m => m.Editorial)
                .WithMany(m => m.Libros) // que entidad padre es 
                .HasForeignKey(m => m) // donde esta la foreign key
                .IsRequired() // es requerido la relacion
                .OnDelete(DeleteBehavior.Restrict); // con borrado en cascada

            modelBuilder.Entity<Libro>()
                .HasMany(m => m.Autores)
                .WithMany(t => t.Libros)
                .UsingEntity<LibroAutor>(
                    p => p.HasKey(k => new { k.LibroId, k.AutorId })
                );

            modelBuilder.Entity<Libro>()
                .HasMany(m => m.Generos)
                .WithMany(t => t.Libros)
                .UsingEntity<LibroGenero>(
                    p => p.HasKey(k => new { k.LibroId, k.GeneroId })
    );

        }


    }
}
