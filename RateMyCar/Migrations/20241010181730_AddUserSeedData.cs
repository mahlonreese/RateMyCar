using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMyCar.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "full_name", "password", "username" },
                values: new object[,]
                {
                    { 1, "mahlon@gmail.com", "Mahlon Reese", "Test123", "mahlonreese" },
                    { 2, "melanie@gmail.com", "Melanie Ehrlich", "Test321", "melanieehrlich" },
                    { 3, "thum@gmail.com", "Thum Rangsiyawaranon", "Password123", "thumrang" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3);
        }
    }
}
