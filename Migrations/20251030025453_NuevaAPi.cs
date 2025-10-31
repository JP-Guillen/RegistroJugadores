using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroJugadores.Migrations
{
    /// <inheritdoc />
    public partial class NuevaAPi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    Victorias = table.Column<int>(type: "INTEGER", nullable: false),
                    Empates = table.Column<int>(type: "INTEGER", nullable: false),
                    Derrotas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "partidas",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Jugador1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Jugador2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoPartida = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GanadorId = table.Column<int>(type: "INTEGER", nullable: true),
                    TurnoJugadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoTablero = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partidas", x => x.PartidaId);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_Jugador1Id",
                        column: x => x.Jugador1Id,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_Jugador2Id",
                        column: x => x.Jugador2Id,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partidas_Jugadores_TurnoJugadorId",
                        column: x => x.TurnoJugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    MovimientoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    JugadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicionFila = table.Column<int>(type: "INTEGER", nullable: false),
                    PosicionColumna = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaMoviemiento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_movimientos_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientos_partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "partidas",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_JugadorId",
                table: "movimientos",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_PartidaId",
                table: "movimientos",
                column: "PartidaId");

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
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "partidas");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
