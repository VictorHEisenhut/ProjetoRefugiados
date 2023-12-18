using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDocumentoAUmRefugiadoEAlterandoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                table: "Refugiados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Enderecos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Refugiados_DocumentoId",
                table: "Refugiados",
                column: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refugiados_Documentos_DocumentoId",
                table: "Refugiados",
                column: "DocumentoId",
                principalTable: "Documentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Enderecos");
        }
    }
}
