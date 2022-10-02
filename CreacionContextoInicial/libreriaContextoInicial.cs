using Libreria.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CreacionContextoInicial
{

    public class libreriaContextoInicial : DbContext
    {

        private const string conexion = @"Data Source = RICHI-PC;Initial Catalog=Libreria2;Integrated Security=true";

        public DbSet<Libro>? Libro { get; set; }
        public DbSet<Autor>? Autor { get; set; }
        public DbSet<Genero>? Genero { get; set; }
        public DbSet<Editorial>? Editorial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(conexion).LogTo(message => Debug.WriteLine(message));//.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information).EnableSensitiveDataLogging();


        }

    }

}
