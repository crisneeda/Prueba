using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.Migrations
{
    /// <inheritdoc />
    public partial class Version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duenos",
                columns: table => new
                {
                    Id_duenos_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duenos", x => x.Id_duenos_PK);
                });

            migrationBuilder.CreateTable(
                name: "coches",
                columns: table => new
                {
                    Id_Coche_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duenoId_duenos_PK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coches", x => x.Id_Coche_PK);
                    table.ForeignKey(
                        name: "FK_coches_duenos_duenoId_duenos_PK",
                        column: x => x.duenoId_duenos_PK,
                        principalTable: "duenos",
                        principalColumn: "Id_duenos_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coches_duenoId_duenos_PK",
                table: "coches",
                column: "duenoId_duenos_PK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coches");

            migrationBuilder.DropTable(
                name: "duenos");
        }
    }
}
