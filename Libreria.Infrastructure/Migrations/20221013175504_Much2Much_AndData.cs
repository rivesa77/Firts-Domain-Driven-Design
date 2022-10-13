using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.Infrastructure.Migrations
{
    public partial class Much2Much_AndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paginas = table.Column<int>(type: "int", nullable: false),
                    EditorialId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libro_Editorial_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroAutor",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroAutor", x => new { x.LibroId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_LibroAutor_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroAutor_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroGenero",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroGenero", x => new { x.LibroId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_LibroGenero_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroGenero_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precio_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "Id", "Biografia", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "es uno de los autores más influyentes de la historia. Su obra, publicada a inicios del siglo XX tardó unos años en encontrar aceptación entre un público más amplio. Entre 1929 y 1936, lanzó cuatro novelas: “El sonido y la furia”, “Mientras agonizo”, “Luz de agosto” y “¡Absalom, Absalom!” que definirían su estilo, inmerso en la exploración de la moralidad dentro del gótico sureño. Sus obras le valieron el Premio Nobel de Literatura en 1949, lo que le dio un nuevo vuelco a su fama.", null, null, null, null, "AMERICANO", "WILLIAM FAULKNER" },
                    { 2, "fue un escritor y poeta irlandés cuyo nombre real era Oscar Fingal O'Flahertie Wills Wilde. Nació el 16 de octubre de 1854 en Dublín (Irlanda) y, a principios de la década de 1890, se convirtió en el dramaturgo más famoso de todo Londres. Fue encarcelado, lo que más tarde condujo a su fallecimiento temprano. Hoy es recordado por obras tan notables como “La importancia de llamarse Ernesto”, “El retrato de Dorian Gray”, “El fantasma de Canterville” o “De profundis”", null, null, null, null, "IRLANDES", "OSCAR WILDE" },
                    { 3, "En estos días, cada vez que una historia toma un giro surrealista u horrible que pone de relieve la complejidad invencible de un sistema sin rostro, lo llamamos \"kafkiano\". “El proceso” es una novela desgarradora sobre un hombre perseguido por una autoridad omnisciente por un crimen cuya naturaleza nunca se revela. “La Metamorfosis” es un libro igualmente perturbador en el que el narrador se despierta viendo que se ha convertido en un insecto gigante. Las historias de Franz Kafka sondean las áreas más oscuras y menos transitadas de la condición humana, y aunque solo tenía 40 años cuando murió en 1924 (se murió de hambre cuando la tuberculosis hizo que comer fuera demasiado doloroso), sus obras le valieron la reputación de ser uno de los escritores más fabulosos del siglo XX.", null, null, null, null, "AMERICANO", "FRANZ KAFKA" },
                    { 4, "nació el 2 de febrero de 1882 y es considerado uno de los autores más influyentes de la historia de la literatura. Sus obras más conocidas son: “Ulises”, “Dublineses”, “Los muertos” o “Eveline”. Una increíble estatua en su honor se encuentra en North Earl Street en Dublín ", null, null, null, null, "ESPAÑOLA", "FALCONES, ILDEFONSO" },
                    { 5, "Luis García Montero ​ es un poeta y crítico literario español, ensayista, catedrático de Literatura Española en la Universidad de Granada. Pertenece a la generación de los ochenta o postnovísimos dentro de la corriente denominada poesía de la experiencia. Desde 2018 es Director del Instituto Cervantes.", null, null, null, null, "ESPAÑOLA", "GARCÍA MONTERO, LUIS" },
                    { 6, "Joël Dicker es un escritor suizo nacido el 16 de junio del año 1985 en la ciudad de Ginebra.\r\n\r\nEs hijo de un profesor de instituto y de una librera. Tiene tres hermanos.\r\n\r\nSu primer acercamiento a la escritura se produjo en su infancia, cuando en el colegio dirigió una revista de naturaleza y animales.\r\n\r\nEn principio, Joel quería dedicarse a la interpretación, y para ello acudió a París a estudiar arte dramático.", null, null, null, null, "SUIZO", "DICKER, JOËL" },
                    { 7, "Stephen Edwin King, más conocido como Stephen King y ocasionalmente por su pseudónimo Richard Bachman, es un escritor estadounidense de novelas de terror, ficción sobrenatural, misterio, ciencia ficción y literatura fantástica", null, null, null, null, "AMERICANO", "KING, STEPHEN" },
                    { 8, "Es un mangaka japonés.Matsumoto nació en la región de Kinki, en la prefectura de Hyogo. Estudió en el Asagaya Art College.\r\n\r\nEn 2005, ganó el 27º premio Jump Top 10 Rookie Manga, lo que le permitió empezar a publicar su primer manga, Nekoromancer.", null, null, null, null, "JAPONES", "MATSUMOTO, NAOYA" },
                    { 9, "Taylor Jenkins Reid es una escritora, productora de televisión y guionista estadounidense. Escribe principalmente romance y sus obras más destacadas son Los siete maridos de Evelyn Hugo y Todos quieren a Daisy Jones.", null, null, null, null, "INGLES", "JENKINS REID, TAYLOR" },
                    { 10, "El conferencista James Clear es un escritor bestseller centrado en los hábitos, la toma de decisiones y la mejora continua. Es el autor del éxito de ventas número 1 del New York Times, Hábitos Atómicos (Atomic Habits). El libro se ha traducido a más de 50 idiomas y ha vendido más de 5 millones de copias.", null, null, null, null, "INGLES", "CLEAR, JAMES" }
                });

            migrationBuilder.InsertData(
                table: "Editorial",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "La vaca" },
                    { 2, null, null, null, null, "Panfleto" },
                    { 3, null, null, null, null, "Editorial Anagrama" },
                    { 4, null, null, null, null, "Nube de Tinta" },
                    { 5, null, null, null, null, "Espasa" },
                    { 6, null, null, null, null, "Tusquets Editores" },
                    { 7, null, null, null, null, "Grijalbo" }
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Ficcion Moderna" },
                    { 2, null, null, null, null, "Biografia" },
                    { 3, null, null, null, null, "Crimen y misterio" },
                    { 4, null, null, null, null, "Motivación personal" },
                    { 5, null, null, null, null, "Realismo mágico" },
                    { 6, null, null, null, null, "Misterio" },
                    { 7, null, null, null, null, "Ficción clásica" },
                    { 8, null, null, null, null, "Fantasía" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "Id", "Asin", "CreatedBy", "CreatedDate", "EditorialId", "LastModifiedBy", "LastModifiedDate", "Paginas", "Titulo" },
                values: new object[,]
                {
                    { 1, "978-84-1107-160-4", null, null, 1, null, null, 180, "Esclava de la libertad" },
                    { 2, "978-84-253-6179-1", null, null, 1, null, null, 148, "Un año y tres meses" },
                    { 3, "978-84-339-9954-2", null, null, 2, null, null, 520, "Personas decentes" },
                    { 4, "978-84-16588-43-5", null, null, 2, null, null, 350, "Invisible" },
                    { 5, "978-84-670-5330-2", null, null, 3, null, null, 351, "Cómo hacer que te pasen cosas buenas" },
                    { 6, "978-84-670-6221-2", null, null, 4, null, null, 641, "Encuentra tu persona vitamina" },
                    { 7, "978-84-204-6212-7", null, null, 5, null, null, 852, "El caso Alaska Sanders" },
                    { 8, "978-84-01-02771-0", null, null, 6, null, null, 963, "Cuento de hadas" },
                    { 9, "8457-96541574", null, null, 7, null, null, 357, "Las hijas del Capitán" }
                });

            migrationBuilder.InsertData(
                table: "LibroAutor",
                columns: new[] { "AutorId", "LibroId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null },
                    { 2, 2, null, null, null, null },
                    { 3, 3, null, null, null, null },
                    { 4, 4, null, null, null, null },
                    { 5, 5, null, null, null, null },
                    { 1, 6, null, null, null, null },
                    { 5, 6, null, null, null, null },
                    { 2, 7, null, null, null, null },
                    { 3, 8, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "LibroGenero",
                columns: new[] { "GeneroId", "LibroId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null },
                    { 2, 1, null, null, null, null },
                    { 2, 2, null, null, null, null },
                    { 3, 3, null, null, null, null },
                    { 4, 4, null, null, null, null },
                    { 5, 4, null, null, null, null },
                    { 6, 5, null, null, null, null },
                    { 7, 6, null, null, null, null },
                    { 8, 7, null, null, null, null },
                    { 3, 8, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_EditorialId",
                table: "Libro",
                column: "EditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutor_AutorId",
                table: "LibroAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroGenero_GeneroId",
                table: "LibroGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_LibroId",
                table: "Precio",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroAutor");

            migrationBuilder.DropTable(
                name: "LibroGenero");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
