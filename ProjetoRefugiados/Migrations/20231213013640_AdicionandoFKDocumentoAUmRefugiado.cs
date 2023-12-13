using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFKDocumentoAUmRefugiado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                table: "Refugiados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refugiados_DocumentoId",
                table: "Refugiados",
                column: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refugiados_Documentos_DocumentoId",
                table: "Refugiados",
                column: "DocumentoId",
                principalTable: "Documentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refugiados_Documentos_DocumentoId",
                table: "Refugiados");

            migrationBuilder.DropIndex(
                name: "IX_Refugiados_DocumentoId",
                table: "Refugiados");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                table: "Refugiados");
        }
    }
}
