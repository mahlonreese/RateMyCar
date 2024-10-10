using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMyCar.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "review",
                columns: new[] { "review_id", "car_id", "comments", "date_posted", "photo_url", "rating", "user_id" },
                values: new object[,]
                {
                    { 1, 1, "Amazing car, probably the best ever", new DateOnly(2023, 2, 20), "", 5, 1 },
                    { 2, 2, "Would not buy again, not 10/10", new DateOnly(2024, 4, 23), "", 1, 2 },
                    { 3, 3, "Got the job done, it is very reliable", new DateOnly(2020, 11, 10), "", 4, 3 },
                    { 4, 4, "Stay away, it worked for 3 months", new DateOnly(2024, 9, 28), "", 2, 1 },
                    { 5, 5, "Very reliable, just not that stylish", new DateOnly(2024, 2, 27), "", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 5);
        }
    }
}
