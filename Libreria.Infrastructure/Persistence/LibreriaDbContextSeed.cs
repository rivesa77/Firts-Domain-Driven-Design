using Libreria.Domain;

namespace Libreria.Infrastructure.Persistence
{
    public class LibreriaDbContextSeed
    {
        public static IEnumerable<Editorial> GetPreconfiguredEditorial()
        {
            return new List<Editorial>
            {
                new Editorial {Nombre="La vaca",Id=1},
                new Editorial {Nombre="Panfleto",Id=2},
                new Editorial {Nombre="Editorial Anagrama",Id=3},
                new Editorial {Nombre="Nube de Tinta",Id=4},
                new Editorial {Nombre="Espasa",Id=5},
                new Editorial {Nombre="Tusquets Editores",Id=6},
                new Editorial {Nombre="Grijalbo",Id=7},
            };
        }

        public static IEnumerable<Autor> GetPreconfiguredAutor()
        {
            return new List<Autor>
            {
                new Autor {Nombre="WILLIAM FAULKNER",Biografia="es uno de los autores más influyentes de la historia. Su obra, publicada a inicios del siglo XX tardó unos años en encontrar aceptación entre un público más amplio. Entre 1929 y 1936, lanzó cuatro novelas: “El sonido y la furia”, “Mientras agonizo”, “Luz de agosto” y “¡Absalom, Absalom!” que definirían su estilo, inmerso en la exploración de la moralidad dentro del gótico sureño. Sus obras le valieron el Premio Nobel de Literatura en 1949, lo que le dio un nuevo vuelco a su fama."
                ,Nacionalidad="AMERICANO",Id=1},
                new Autor {Nombre="OSCAR WILDE",Biografia="fue un escritor y poeta irlandés cuyo nombre real era Oscar Fingal O'Flahertie Wills Wilde. Nació el 16 de octubre de 1854 en Dublín (Irlanda) y, a principios de la década de 1890, se convirtió en el dramaturgo más famoso de todo Londres. Fue encarcelado, lo que más tarde condujo a su fallecimiento temprano. Hoy es recordado por obras tan notables como “La importancia de llamarse Ernesto”, “El retrato de Dorian Gray”, “El fantasma de Canterville” o “De profundis”"
                ,Nacionalidad="IRLANDES",Id=2},
                new Autor {Nombre="FRANZ KAFKA",Biografia="En estos días, cada vez que una historia toma un giro surrealista u horrible que pone de relieve la complejidad invencible de un sistema sin rostro, lo llamamos \"kafkiano\". “El proceso” es una novela desgarradora sobre un hombre perseguido por una autoridad omnisciente por un crimen cuya naturaleza nunca se revela. “La Metamorfosis” es un libro igualmente perturbador en el que el narrador se despierta viendo que se ha convertido en un insecto gigante. Las historias de Franz Kafka sondean las áreas más oscuras y menos transitadas de la condición humana, y aunque solo tenía 40 años cuando murió en 1924 (se murió de hambre cuando la tuberculosis hizo que comer fuera demasiado doloroso), sus obras le valieron la reputación de ser uno de los escritores más fabulosos del siglo XX."
                ,Nacionalidad="AMERICANO",Id=3},
                new Autor {Nombre="FALCONES, ILDEFONSO",Biografia="nació el 2 de febrero de 1882 y es considerado uno de los autores más influyentes de la historia de la literatura. Sus obras más conocidas son: “Ulises”, “Dublineses”, “Los muertos” o “Eveline”. Una increíble estatua en su honor se encuentra en North Earl Street en Dublín "
                ,Nacionalidad="ESPAÑOLA",Id=4},
                new Autor {Nombre="GARCÍA MONTERO, LUIS",Biografia="Luis García Montero ​ es un poeta y crítico literario español, ensayista, catedrático de Literatura Española en la Universidad de Granada. Pertenece a la generación de los ochenta o postnovísimos dentro de la corriente denominada poesía de la experiencia. Desde 2018 es Director del Instituto Cervantes."
                ,Nacionalidad="ESPAÑOLA",Id=5},
                new Autor {Nombre="DICKER, JOËL",Biografia="Joël Dicker es un escritor suizo nacido el 16 de junio del año 1985 en la ciudad de Ginebra.\r\n\r\nEs hijo de un profesor de instituto y de una librera. Tiene tres hermanos.\r\n\r\nSu primer acercamiento a la escritura se produjo en su infancia, cuando en el colegio dirigió una revista de naturaleza y animales.\r\n\r\nEn principio, Joel quería dedicarse a la interpretación, y para ello acudió a París a estudiar arte dramático."
                ,Nacionalidad="SUIZO",Id=6},
                new Autor {Nombre="KING, STEPHEN",Biografia="Stephen Edwin King, más conocido como Stephen King y ocasionalmente por su pseudónimo Richard Bachman, es un escritor estadounidense de novelas de terror, ficción sobrenatural, misterio, ciencia ficción y literatura fantástica"
                ,Nacionalidad="AMERICANO",Id=7},
                new Autor {Nombre="MATSUMOTO, NAOYA",Biografia="Es un mangaka japonés.Matsumoto nació en la región de Kinki, en la prefectura de Hyogo. Estudió en el Asagaya Art College.\r\n\r\nEn 2005, ganó el 27º premio Jump Top 10 Rookie Manga, lo que le permitió empezar a publicar su primer manga, Nekoromancer."
                ,Nacionalidad="JAPONES",Id=8},
                new Autor {Nombre="JENKINS REID, TAYLOR",Biografia="Taylor Jenkins Reid es una escritora, productora de televisión y guionista estadounidense. Escribe principalmente romance y sus obras más destacadas son Los siete maridos de Evelyn Hugo y Todos quieren a Daisy Jones."
                ,Nacionalidad="INGLES",Id=9},
                new Autor {Nombre="CLEAR, JAMES",Biografia="El conferencista James Clear es un escritor bestseller centrado en los hábitos, la toma de decisiones y la mejora continua. Es el autor del éxito de ventas número 1 del New York Times, Hábitos Atómicos (Atomic Habits). El libro se ha traducido a más de 50 idiomas y ha vendido más de 5 millones de copias."
                ,Nacionalidad="INGLES",Id=10},
            };
        }

        public static IEnumerable<Genero> GetPreconfiguredGenero()
        {
            return new List<Genero>
            {
                new Genero {Nombre="Ficcion Moderna",Id=1},
                new Genero {Nombre="Biografia",Id=2},
                new Genero {Nombre="Crimen y misterio",Id=3},
                new Genero {Nombre="Motivación personal",Id=4},
                new Genero {Nombre="Realismo mágico",Id=5},
                new Genero {Nombre="Misterio",Id=6},
                new Genero {Nombre="Ficción clásica",Id=7},
                new Genero {Nombre="Fantasía",Id=8},
            };
        }

        public static IEnumerable<Libro> GetPreconfiguredLibro()
        {
            return new List<Libro>
            {
                new Libro {Titulo="Esclava de la libertad",Asin="978-84-1107-160-4",Paginas=180,EditorialId=1,Id=1},
                new Libro {Titulo="Un año y tres meses",Asin="978-84-253-6179-1",Paginas=148,EditorialId=1,Id=2},
                new Libro {Titulo="Personas decentes",Asin="978-84-339-9954-2",Paginas=520,EditorialId=2,Id=3},
                new Libro {Titulo="Invisible",Asin="978-84-16588-43-5",Paginas=350,EditorialId=2,Id=4},
                new Libro {Titulo="Cómo hacer que te pasen cosas buenas",Asin="978-84-670-5330-2",Paginas=351, EditorialId = 3,Id=5},
                new Libro {Titulo="Encuentra tu persona vitamina",Asin="978-84-670-6221-2",Paginas=641, EditorialId = 4,Id=6},
                new Libro {Titulo="El caso Alaska Sanders",Asin="978-84-204-6212-7",Paginas=852, EditorialId = 5,Id=7},
                new Libro {Titulo="Cuento de hadas",Asin="978-84-01-02771-0",Paginas=963, EditorialId = 6,Id=8},
                new Libro {Titulo="Las hijas del Capitán",Asin="8457-96541574",Paginas=357, EditorialId = 7,Id=9},
            };
        }

        public static IEnumerable<LibroAutor> GetPreconfiguredLibroAutor()
        {
            return new List<LibroAutor>
            {
                new LibroAutor {AutorId=1,LibroId=1},
                new LibroAutor {AutorId=2,LibroId=2},
                new LibroAutor {AutorId=3,LibroId=3},
                new LibroAutor {AutorId=4,LibroId=4},
                new LibroAutor {AutorId=5,LibroId=5},
                new LibroAutor {AutorId=5,LibroId=6},
                new LibroAutor {AutorId=1,LibroId=6},
                new LibroAutor {AutorId=2,LibroId=7},
                new LibroAutor {AutorId=3,LibroId=8},
            };
        }

        public static IEnumerable<LibroGenero> GetPreconfiguredLibroGenero()
        {
            return new List<LibroGenero>
            {
                new LibroGenero {GeneroId=1,LibroId=1},
                new LibroGenero {GeneroId=2,LibroId=1},
                new LibroGenero {GeneroId=2,LibroId=2},
                new LibroGenero {GeneroId=3,LibroId=3},
                new LibroGenero {GeneroId=4,LibroId=4},
                new LibroGenero {GeneroId=5,LibroId=4},
                new LibroGenero {GeneroId=6,LibroId=5},
                new LibroGenero {GeneroId=7,LibroId=6},
                new LibroGenero {GeneroId=8,LibroId=7},
                new LibroGenero {GeneroId=3,LibroId=8},
            };
        }
    }
}