using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    /// <inheritdoc />
    public partial class AddFkdeParentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParenteId",
                table: "Filhos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filhos_ParenteId",
                table: "Filhos",
                column: "ParenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filhos_Refugiados_ParenteId",
                table: "Filhos",
                column: "ParenteId",
                principalTable: "Refugiados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filhos_Refugiados_ParenteId",
                table: "Filhos");

            migrationBuilder.DropIndex(
                name: "IX_Filhos_ParenteId",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "ParenteId",
                table: "Filhos");
        }
    }
}
