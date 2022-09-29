using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreacionContextoInicial.Migrations
{
    public partial class ModelosInicial : Migration
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
                name: "AutorLibro",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    LibrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => new { x.AutoresId, x.LibrosId });
                    table.ForeignKey(
                        name: "FK_AutorLibro_Autor_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLibro_Libro_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroLibro",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    LibrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroLibro", x => new { x.GenerosId, x.LibrosId });
                    table.ForeignKey(
                        name: "FK_GeneroLibro_Genero_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroLibro_Libro_LibrosId",
                        column: x => x.LibrosId,
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

            migrationBuilder.CreateIndex(
                name: "IX_AutorLibro_LibrosId",
                table: "AutorLibro",
                column: "LibrosId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroLibro_LibrosId",
                table: "GeneroLibro",
                column: "LibrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_EditorialId",
                table: "Libro",
                column: "EditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_LibroId",
                table: "Precio",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLibro");

            migrationBuilder.DropTable(
                name: "GeneroLibro");

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
