using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroJugadores.Migrations
{
    /// <inheritdoc />
    public partial class Agregandotodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Jugadores_JugadorId",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_partidas_PartidaId",
                table: "Movimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimientos",
                table: "Movimientos");

            migrationBuilder.RenameTable(
                name: "Movimientos",
                newName: "movimientos");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_PartidaId",
                table: "movimientos",
                newName: "IX_movimientos_PartidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_JugadorId",
                table: "movimientos",
                newName: "IX_movimientos_JugadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movimientos",
                table: "movimientos",
                column: "MovimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientos_Jugadores_JugadorId",
                table: "movimientos",
                column: "JugadorId",
                principalTable: "Jugadores",
                principalColumn: "JugadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientos_partidas_PartidaId",
                table: "movimientos",
                column: "PartidaId",
                principalTable: "partidas",
                principalColumn: "PartidaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientos_Jugadores_JugadorId",
                table: "movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientos_partidas_PartidaId",
                table: "movimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movimientos",
                table: "movimientos");

            migrationBuilder.RenameTable(
                name: "movimientos",
                newName: "Movimientos");

            migrationBuilder.RenameIndex(
                name: "IX_movimientos_PartidaId",
                table: "Movimientos",
                newName: "IX_Movimientos_PartidaId");

            migrationBuilder.RenameIndex(
                name: "IX_movimientos_JugadorId",
                table: "Movimientos",
                newName: "IX_Movimientos_JugadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimientos",
                table: "Movimientos",
                column: "MovimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Jugadores_JugadorId",
                table: "Movimientos",
                column: "JugadorId",
                principalTable: "Jugadores",
                principalColumn: "JugadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_partidas_PartidaId",
                table: "Movimientos",
                column: "PartidaId",
                principalTable: "partidas",
                principalColumn: "PartidaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
