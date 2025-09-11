using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroJugadores.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoModeloPartida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "partidas",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugador1Id = table.Column<int>(type: "int", nullable: false),
                    Jugador2Id = table.Column<int>(type: "int", nullable: true),
                    EstadoPartida = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GanadorId = table.Column<int>(type: "int", nullable: true),
                    TurnoJugadorId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partidas", x => x.PartidaId);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Idjugador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_Jugador1Id",
                        column: x => x.Jugador1Id,
                        principalTable: "Jugadores",
                        principalColumn: "Idjugador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_Jugador2Id",
                        column: x => x.Jugador2Id,
                        principalTable: "Jugadores",
                        principalColumn: "Idjugador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_TurnoJugadorId",
                        column: x => x.TurnoJugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Idjugador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_partidas_GanadorId",
                table: "partidas",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_partidas_Jugador1Id",
                table: "partidas",
                column: "Jugador1Id");

            migrationBuilder.CreateIndex(
                name: "IX_partidas_Jugador2Id",
                table: "partidas",
                column: "Jugador2Id");

            migrationBuilder.CreateIndex(
                name: "IX_partidas_TurnoJugadorId",
                table: "partidas",
                column: "TurnoJugadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "partidas");
        }
    }
}
