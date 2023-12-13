using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoEnderecosAddEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Estado",
                table: "Enderecos");
        }
    }
}
