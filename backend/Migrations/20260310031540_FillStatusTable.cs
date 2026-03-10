using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonBlog.Migrations
{
    /// <inheritdoc />
    public partial class FillStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "statuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Declined" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<bool>(
                name: "Description",
                table: "statuses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
