using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Buil01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Voos",
                newName: "Voo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Voo",
                table: "Voos",
                newName: "Descricao");
        }
    }
}
