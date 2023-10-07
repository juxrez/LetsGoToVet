using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsGoToVet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Initial_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 0, "Astro" });

            migrationBuilder.InsertData(
                table: "Veterinaries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Arana Pet" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veterinaries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
