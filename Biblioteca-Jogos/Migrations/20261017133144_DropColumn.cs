using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class DropColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jogo",
                table: "Lista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Jogo",
                table: "Lista",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
