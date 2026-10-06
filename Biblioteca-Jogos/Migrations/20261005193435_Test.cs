using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusJogo",
                table: "Jogo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Avaliacao",
                table: "Jogo",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Jogo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jogo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Avaliacao",
                table: "Jogo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");

            migrationBuilder.AddColumn<int>(
                name: "StatusJogo",
                table: "Jogo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
