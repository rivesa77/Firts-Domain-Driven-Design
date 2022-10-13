using Libreria.Domain;
using Libreria.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Libreria.Infrastructure.Persistence
{

    public class LibreriaDbContext : DbContext
    {

        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options)
        {
        }

        public DbSet<Libro>? Libro { get; set; }
        public DbSet<Editorial>? Editorial { get; set; }
        public DbSet<Genero>? Genero { get; set; }
        public DbSet<Autor>? Autor { get; set; }
        public DbSet<LibroAutor>? LibroAutor { get; set; }

        public DbSet<LibroGenero>? LibroGenero { get; set; }


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


            modelBuilder.Entity<Editorial>()
                .HasMany(m => m.Libros) //muchos libros
                .WithOne(m => m.Editorial) // que entidad padre es 
                .HasForeignKey(m => m.EditorialId) // donde esta la foreign key
                .IsRequired(); // es requerido la relacion


            
            //modelBuilder.Entity<Libro>()
            //   .HasMany(m => m.Autores) //muchos libros
            //   .WithMany(m => m.Libros) // que entidad padre es                
               
            //   .UsingEntity<LibroAutor>(
            //        p => p.HasKey(e => new { e.LibroId, e.AutorId,e.Id })
            //    );


            // Muchos a muchos
            modelBuilder.Entity<Libro>()
                .HasMany(a => a.Autores)
                .WithMany(v => v.Libros)
                .UsingEntity<LibroAutor>(
                    j => j
                       .HasOne(p => p.Autor)
                       .WithMany(p => p.LibroAutor)
                       .HasForeignKey(p => p.AutorId),
                    j => j
                        .HasOne(p => p.Libro)
                        .WithMany(p => p.LibroAutor)
                        .HasForeignKey(p => p.LibroId),
                    j =>
                    {
                        j.HasKey(t => new { t.LibroId, t.AutorId });
                    }
                );

            modelBuilder.Entity<LibroAutor>().Ignore(va => va.Id);


            // Muchos a muchos
            modelBuilder.Entity<Libro>()
                            .HasMany(a => a.Generos)
                            .WithMany(v => v.Libros)
                            .UsingEntity<LibroGenero>(
                                j => j
                                   .HasOne(p => p.Genero)
                                   .WithMany(p => p.LibroGenero)
                                   .HasForeignKey(p => p.GeneroId),
                                j => j
                                    .HasOne(p => p.Libro)
                                    .WithMany(p => p.LibroGenero)
                                    .HasForeignKey(p => p.LibroId),
                                j =>
                                {
                                    j.HasKey(t => new { t.LibroId, t.GeneroId });
                                }
                            );

            modelBuilder.Entity<LibroGenero>().Ignore(va => va.Id);



            modelBuilder.Entity<Editorial>().HasData(LibreriaDbContextSeed.GetPreconfiguredEditorial());
            modelBuilder.Entity<Autor>().HasData(LibreriaDbContextSeed.GetPreconfiguredAutor());
            modelBuilder.Entity<Genero>().HasData(LibreriaDbContextSeed.GetPreconfiguredGenero());
            modelBuilder.Entity<Libro>().HasData(LibreriaDbContextSeed.GetPreconfiguredLibro());
            modelBuilder.Entity<LibroAutor>().HasData(LibreriaDbContextSeed.GetPreconfiguredLibroAutor());
            modelBuilder.Entity<LibroGenero>().HasData(LibreriaDbContextSeed.GetPreconfiguredLibroGenero());

        }


       
    }
}
