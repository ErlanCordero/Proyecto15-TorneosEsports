using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneosEsports.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaBitacora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BitacoraAcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraAcciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitacoraAcciones");
        }
    }
}
