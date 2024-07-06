using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio2.Migrations
{
    /// <inheritdoc />
    public partial class TablasObl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locales",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomRespon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeleRespon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locales", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "rutinas",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRutina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalifRutinaPromedio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutinas", x => x.IdRutina);
                });

            migrationBuilder.CreateTable(
                name: "tipomaquinas",
                columns: table => new
                {
                    IdTipoMaq = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipomaquinas", x => x.IdTipoMaq);
                });

            migrationBuilder.CreateTable(
                name: "socios",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socios", x => x.IdSocio);
                    table.ForeignKey(
                        name: "FK_socios_locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "locales",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ejercicios",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaq = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ejercicios", x => x.IdEjercicio);
                    table.ForeignKey(
                        name: "FK_ejercicios_tipomaquinas_IdTipoMaq",
                        column: x => x.IdTipoMaq,
                        principalTable: "tipomaquinas",
                        principalColumn: "IdTipoMaq",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maquinas",
                columns: table => new
                {
                    IdMaq = table.Column<int>(type: "int", nullable: false),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaq = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maquinas", x => x.IdMaq);
                    table.ForeignKey(
                        name: "FK_maquinas_locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "locales",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maquinas_tipomaquinas_IdTipoMaq",
                        column: x => x.IdTipoMaq,
                        principalTable: "tipomaquinas",
                        principalColumn: "IdTipoMaq",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sociorutinas",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sociorutinas", x => new { x.IdSocio, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_sociorutinas_rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "rutinas",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sociorutinas_socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "socios",
                        principalColumn: "IdSocio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rutinaejercicios",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    IdEjercicio = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutinaejercicios", x => new { x.IdRutina, x.IdEjercicio });
                    table.ForeignKey(
                        name: "FK_rutinaejercicios_ejercicios_IdEjercicio",
                        column: x => x.IdEjercicio,
                        principalTable: "ejercicios",
                        principalColumn: "IdEjercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rutinaejercicios_rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "rutinas",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ejercicios_IdTipoMaq",
                table: "ejercicios",
                column: "IdTipoMaq");

            migrationBuilder.CreateIndex(
                name: "IX_maquinas_IdLocal",
                table: "maquinas",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_maquinas_IdTipoMaq",
                table: "maquinas",
                column: "IdTipoMaq");

            migrationBuilder.CreateIndex(
                name: "IX_rutinaejercicios_IdEjercicio",
                table: "rutinaejercicios",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_sociorutinas_IdRutina",
                table: "sociorutinas",
                column: "IdRutina");

            migrationBuilder.CreateIndex(
                name: "IX_socios_IdLocal",
                table: "socios",
                column: "IdLocal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maquinas");

            migrationBuilder.DropTable(
                name: "rutinaejercicios");

            migrationBuilder.DropTable(
                name: "sociorutinas");

            migrationBuilder.DropTable(
                name: "ejercicios");

            migrationBuilder.DropTable(
                name: "rutinas");

            migrationBuilder.DropTable(
                name: "socios");

            migrationBuilder.DropTable(
                name: "tipomaquinas");

            migrationBuilder.DropTable(
                name: "locales");
        }
    }
}
