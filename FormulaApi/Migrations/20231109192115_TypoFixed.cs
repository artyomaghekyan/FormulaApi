using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaApi.Migrations
{
    /// <inheritdoc />
    public partial class TypoFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeriverNumber",
                table: "Drivers",
                newName: "DriverNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverNumber",
                table: "Drivers",
                newName: "DeriverNumber");
        }
    }
}
