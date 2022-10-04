using Libreria.Domain;
using Microsoft.Extensions.Logging;

namespace Libreria.Infrastructure.Persistence
{
    public class LibreriaDbContextSeed
    {

        // Ilogger se focaliza en la clase StreamerDBContext
        // Metodo async que permite "setear" data para la tabla streamer
        public static async Task SeedAsync(LibreriaDbContext context, ILogger<LibreriaDbContext> logger)
        {
            try
            {
                //Si no contine datos
                if (!context.Libro!.Any())
                {
                    context.Editorial!.AddRange(GetPreconfiguredEditorial());
                    context.Autor!.AddRange(GetPreconfiguredAutor());
                    context.Genero!.AddRange(GetPreconfiguredGenero());
                    await context.SaveChangesAsync();


                    context.Libro!.AddRange(GetPreconfiguredLibro(context));
                    context.LibroAutor!.AddRange(GetPreconfiguredLibroAutor(context));
                    context.LibroGenero!.AddRange(GetPreconfiguredLibroGenero(context));
                    await context.SaveChangesAsync();

                    logger.LogInformation("Estamos insertando nuevos registros al Db{context}", typeof(LibreriaDbContext).Name);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static IEnumerable<Editorial> GetPreconfiguredEditorial()
        {
            return new List<Editorial>
            {
                new Editorial {Nombre="La vaca"},
                new Editorial {Nombre="Panfleto"},
                new Editorial {Nombre="Editorial Anagrama"},
                new Editorial {Nombre="Nube de Tinta"},
                new Editorial {Nombre="Espasa"},
                new Editorial {Nombre="Tusquets Editores"},
                new Editorial {Nombre="Grijalbo"},
            };
        }


        private static IEnumerable<Autor> GetPreconfiguredAutor()
        {
            return new List<Autor>
            {
                new Autor {Nombre="WILLIAM FAULKNER",Biografia="es uno de los autores más influyentes de la historia. Su obra, publicada a inicios del siglo XX tardó unos años en encontrar aceptación entre un público más amplio. Entre 1929 y 1936, lanzó cuatro novelas: “El sonido y la furia”, “Mientras agonizo”, “Luz de agosto” y “¡Absalom, Absalom!” que definirían su estilo, inmerso en la exploración de la moralidad dentro del gótico sureño. Sus obras le valieron el Premio Nobel de Literatura en 1949, lo que le dio un nuevo vuelco a su fama."
                ,Nacionalidad="AMERICANO"},
                new Autor {Nombre="OSCAR WILDE",Biografia="fue un escritor y poeta irlandés cuyo nombre real era Oscar Fingal O'Flahertie Wills Wilde. Nació el 16 de octubre de 1854 en Dublín (Irlanda) y, a principios de la década de 1890, se convirtió en el dramaturgo más famoso de todo Londres. Fue encarcelado, lo que más tarde condujo a su fallecimiento temprano. Hoy es recordado por obras tan notables como “La importancia de llamarse Ernesto”, “El retrato de Dorian Gray”, “El fantasma de Canterville” o “De profundis”"
                ,Nacionalidad="IRLANDES"},
                new Autor {Nombre="FRANZ KAFKA",Biografia="En estos días, cada vez que una historia toma un giro surrealista u horrible que pone de relieve la complejidad invencible de un sistema sin rostro, lo llamamos \"kafkiano\". “El proceso” es una novela desgarradora sobre un hombre perseguido por una autoridad omnisciente por un crimen cuya naturaleza nunca se revela. “La Metamorfosis” es un libro igualmente perturbador en el que el narrador se despierta viendo que se ha convertido en un insecto gigante. Las historias de Franz Kafka sondean las áreas más oscuras y menos transitadas de la condición humana, y aunque solo tenía 40 años cuando murió en 1924 (se murió de hambre cuando la tuberculosis hizo que comer fuera demasiado doloroso), sus obras le valieron la reputación de ser uno de los escritores más fabulosos del siglo XX."
                ,Nacionalidad="AMERICANO"},
                new Autor {Nombre="FALCONES, ILDEFONSO",Biografia="nació el 2 de febrero de 1882 y es considerado uno de los autores más influyentes de la historia de la literatura. Sus obras más conocidas son: “Ulises”, “Dublineses”, “Los muertos” o “Eveline”. Una increíble estatua en su honor se encuentra en North Earl Street en Dublín "
                ,Nacionalidad="ESPAÑOLA"},
                new Autor {Nombre="GARCÍA MONTERO, LUIS",Biografia="Luis García Montero ​ es un poeta y crítico literario español, ensayista, catedrático de Literatura Española en la Universidad de Granada. Pertenece a la generación de los ochenta o postnovísimos dentro de la corriente denominada poesía de la experiencia. Desde 2018 es Director del Instituto Cervantes."
                ,Nacionalidad="ESPAÑOLA"},
                new Autor {Nombre="DICKER, JOËL",Biografia="Joël Dicker es un escritor suizo nacido el 16 de junio del año 1985 en la ciudad de Ginebra.\r\n\r\nEs hijo de un profesor de instituto y de una librera. Tiene tres hermanos.\r\n\r\nSu primer acercamiento a la escritura se produjo en su infancia, cuando en el colegio dirigió una revista de naturaleza y animales.\r\n\r\nEn principio, Joel quería dedicarse a la interpretación, y para ello acudió a París a estudiar arte dramático."
                ,Nacionalidad="SUIZO"},
                new Autor {Nombre="KING, STEPHEN",Biografia="Stephen Edwin King, más conocido como Stephen King y ocasionalmente por su pseudónimo Richard Bachman, es un escritor estadounidense de novelas de terror, ficción sobrenatural, misterio, ciencia ficción y literatura fantástica"
                ,Nacionalidad="AMERICANO"},
                new Autor {Nombre="MATSUMOTO, NAOYA",Biografia="Es un mangaka japonés.Matsumoto nació en la región de Kinki, en la prefectura de Hyogo. Estudió en el Asagaya Art College.\r\n\r\nEn 2005, ganó el 27º premio Jump Top 10 Rookie Manga, lo que le permitió empezar a publicar su primer manga, Nekoromancer."
                ,Nacionalidad="JAPONES"},
                new Autor {Nombre="JENKINS REID, TAYLOR",Biografia="Taylor Jenkins Reid es una escritora, productora de televisión y guionista estadounidense. Escribe principalmente romance y sus obras más destacadas son Los siete maridos de Evelyn Hugo y Todos quieren a Daisy Jones."
                ,Nacionalidad="INGLES"},
                new Autor {Nombre="CLEAR, JAMES",Biografia="El conferencista James Clear es un escritor bestseller centrado en los hábitos, la toma de decisiones y la mejora continua. Es el autor del éxito de ventas número 1 del New York Times, Hábitos Atómicos (Atomic Habits). El libro se ha traducido a más de 50 idiomas y ha vendido más de 5 millones de copias."
                ,Nacionalidad="INGLES"},


            };
        }


        private static IEnumerable<Genero> GetPreconfiguredGenero()
        {
            return new List<Genero>
            {
                new Genero {Nombre="Ficcion Moderna"},
                new Genero {Nombre="Biografia"},
                new Genero {Nombre="Crimen y misterio"},
                new Genero {Nombre="Motivación personal"},
                new Genero {Nombre="Realismo mágico"},
                new Genero {Nombre="Misterio"},
                new Genero {Nombre="Ficción clásica"},
                new Genero {Nombre="Fantasía"},

            };
        }



        private static IEnumerable<Libro> GetPreconfiguredLibro(LibreriaDbContext context)
        {
            return new List<Libro>
            {
                new Libro {Titulo="Esclava de la libertad",Asin="978-84-1107-160-4",Paginas=180,EditorialId=context.Editorial.ElementAt(0).Id},
                new Libro {Titulo="Un año y tres meses",Asin="978-84-253-6179-1",Paginas=148,EditorialId=context.Editorial.ElementAt(0).Id},
                new Libro {Titulo="Personas decentes",Asin="978-84-339-9954-2",Paginas=520,EditorialId=context.Editorial.ElementAt(1).Id},
                new Libro {Titulo="Invisible",Asin="978-84-16588-43-5",Paginas=350,EditorialId=context.Editorial.ElementAt(1).Id},
                new Libro {Titulo="Cómo hacer que te pasen cosas buenas",Asin=" 978-84-670-5330-2",Paginas=351, EditorialId = context.Editorial.ElementAt(2).Id},
                new Libro {Titulo="Encuentra tu persona vitamina",Asin="978-84-670-6221-2",Paginas=641, EditorialId = context.Editorial.ElementAt(3).Id},
                new Libro {Titulo="El caso Alaska Sanders",Asin="978-84-204-6212-7",Paginas=852, EditorialId = context.Editorial.ElementAt(4).Id},
                new Libro {Titulo="Cuento de hadas",Asin="978-84-01-02771-0",Paginas=963, EditorialId = context.Editorial.ElementAt(5).Id},
                new Libro {Titulo="Las hijas del Capitán",Asin="8457-96541574",Paginas=357, EditorialId = context.Editorial.ElementAt(6).Id},
            };
        }

        private static IEnumerable<LibroAutor> GetPreconfiguredLibroAutor(LibreriaDbContext context)
        {
            return new List<LibroAutor>
            {
                new LibroAutor {AutorId=context.Autor.ElementAt(0).Id,LibroId=context.Libro.ElementAt(0).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(1).Id,LibroId=context.Libro.ElementAt(1).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(2).Id,LibroId=context.Libro.ElementAt(2).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(3).Id,LibroId=context.Libro.ElementAt(3).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(4).Id,LibroId=context.Libro.ElementAt(4).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(4).Id,LibroId=context.Libro.ElementAt(5).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(0).Id,LibroId=context.Libro.ElementAt(6).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(1).Id,LibroId=context.Libro.ElementAt(7).Id},
                new LibroAutor {AutorId=context.Autor.ElementAt(2).Id,LibroId=context.Libro.ElementAt(8).Id},
            };
        }

        private static IEnumerable<LibroGenero> GetPreconfiguredLibroGenero(LibreriaDbContext context)
        {
            return new List<LibroGenero>
            {
                new LibroGenero {GeneroId=context.Genero.ElementAt(0).Id,LibroId=context.Libro.ElementAt(0).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(1).Id,LibroId=context.Libro.ElementAt(0).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(1).Id,LibroId=context.Libro.ElementAt(1).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(2).Id,LibroId=context.Libro.ElementAt(2).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(3).Id,LibroId=context.Libro.ElementAt(3).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(4).Id,LibroId=context.Libro.ElementAt(4).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(5).Id,LibroId=context.Libro.ElementAt(5).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(6).Id,LibroId=context.Libro.ElementAt(6).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(7).Id,LibroId=context.Libro.ElementAt(7).Id},
                new LibroGenero {GeneroId=context.Genero.ElementAt(2).Id,LibroId=context.Libro.ElementAt(8).Id},
            };
        }

    }
}
