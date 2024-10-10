using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMyCar.Migrations
{
    /// <inheritdoc />
    public partial class CarDataAndChangeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "users",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "car_id", "category", "make", "model", "year" },
                values: new object[,]
                {
                    { 1, "SUV", "Toyota", "Rav 4", 2017 },
                    { 2, "Sedan", "Toyota", "Supra", 2024 },
                    { 3, "Truck", "Toyota", "Tundra", 2018 },
                    { 4, "SUV", "Toyota", "4 Runner", 2024 },
                    { 5, "Truck", "Toyota", "Tacoma", 2022 },
                    { 6, "Sedan", "Ford", "Focus", 2014 },
                    { 7, "Sedan", "Honda", "Accord", 2020 },
                    { 8, "Sedan", "Lexus", "LS", 2023 },
                    { 9, "Sedan", "Lexus", "ES", 2025 },
                    { 10, "SUV", "Lexus", "LX", 2024 },
                    { 11, "Sedan", "BMW", "E30", 1995 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "car",
                keyColumn: "car_id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "users");
        }
    }
}
