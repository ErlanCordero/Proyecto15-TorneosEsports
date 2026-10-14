using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorneosEsports.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntidadesProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CupoPuestos = table.Column<int>(type: "int", nullable: false),
                    PrecioPase = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenciaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCarrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    Juego = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CupoEquipos = table.Column<int>(type: "int", nullable: false),
                    PrecioInscripcion = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    CierreInscripciones = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Torneos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineasPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReferenciaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CapitanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_AspNetUsers_CapitanId",
                        column: x => x.CapitanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntegrantesEquipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nick = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrantesEquipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrantesEquipo_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorneoId = table.Column<int>(type: "int", nullable: false),
                    Ronda = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    EquipoAId = table.Column<int>(type: "int", nullable: true),
                    EquipoBId = table.Column<int>(type: "int", nullable: true),
                    GanadorId = table.Column<int>(type: "int", nullable: true),
                    EsBye = table.Column<bool>(type: "bit", nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoAId",
                        column: x => x.EquipoAId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoBId",
                        column: x => x.EquipoBId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "CupoPuestos", "Descripcion", "Fecha", "FechaCreacion", "ImagenUrl", "Nombre", "PrecioPase", "Sede" },
                values: new object[,]
                {
                    { 1, 200, "Dos días de LAN con torneos de Valorant y League of Legends.", new DateTime(2026, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, "LAN Party Arena Heredia 2026", 8000m, "Centro de convenciones, Heredia" },
                    { 2, 120, "Equipos universitarios compiten en Counter-Strike 2 y Dota 2.", new DateTime(2026, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, "Copa Universitaria de Esports", 5000m, "Gimnasio universitario, San José" },
                    { 3, 80, "Cierre del año con torneos de Overwatch 2 y Rainbow Six Siege.", new DateTime(2026, 12, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), null, "Noche LAN de Fin de Año", 4000m, "Salón comunal, Alajuela" }
                });

            migrationBuilder.InsertData(
                table: "Torneos",
                columns: new[] { "Id", "CierreInscripciones", "CupoEquipos", "Estado", "EventoId", "FechaCreacion", "Formato", "Juego", "PrecioInscripcion" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), 16, "Abierto", 1, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "Valorant", 25000m },
                    { 2, new DateTime(2026, 11, 14, 23, 59, 0, 0, DateTimeKind.Unspecified), 8, "Abierto", 1, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "League of Legends", 25000m },
                    { 3, new DateTime(2026, 11, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), 8, "Abierto", 2, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "Counter-Strike 2", 20000m },
                    { 4, new DateTime(2026, 11, 21, 23, 59, 0, 0, DateTimeKind.Unspecified), 8, "Abierto", 2, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "Dota 2", 20000m },
                    { 5, new DateTime(2026, 11, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 8, "Abierto", 3, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "Overwatch 2", 15000m },
                    { 6, new DateTime(2026, 11, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 8, "Abierto", 3, new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminación directa 5v5", "Rainbow Six Siege", 15000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CapitanId",
                table: "Equipos",
                column: "CapitanId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TorneoId_Nombre",
                table: "Equipos",
                columns: new[] { "TorneoId", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Fecha",
                table: "Eventos",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrantesEquipo_EquipoId",
                table: "IntegrantesEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_UsuarioId",
                table: "ItemsCarrito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_PedidoId",
                table: "LineasPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PedidoId",
                table: "Pagos",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoAId",
                table: "Partidos",
                column: "EquipoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoBId",
                table: "Partidos",
                column: "EquipoBId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_GanadorId",
                table: "Partidos",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_TorneoId_Ronda_Posicion",
                table: "Partidos",
                columns: new[] { "TorneoId", "Ronda", "Posicion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_EventoId_Juego",
                table: "Torneos",
                columns: new[] { "EventoId", "Juego" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrantesEquipo");

            migrationBuilder.DropTable(
                name: "ItemsCarrito");

            migrationBuilder.DropTable(
                name: "LineasPedido");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneos");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
