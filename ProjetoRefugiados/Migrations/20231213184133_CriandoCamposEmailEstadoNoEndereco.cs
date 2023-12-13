using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    /// <inheritdoc />
    public partial class CriandoCamposEmailEstadoNoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
