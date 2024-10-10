using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMyCar.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkForInitialReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 1,
                column: "photo_url",
                value: "https://www.motortrend.com/uploads/sites/5/2016/12/2017-Toyota-RAV4-SE-front-three-quarter-in-motion-02-e1502926043520.jpg");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 2,
                column: "photo_url",
                value: "https://s1.1zoom.me/b5154/579/Toyota_Supra_mk5_GR_A90_Gazoo_Racing_mkV_2.0L_584944_2560x1440.jpg");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 3,
                column: "photo_url",
                value: "https://th.bing.com/th/id/R.6cd93fbb1d81f90a05c82098668438e5?rik=BSK8s2gRoss4uw&pid=ImgRaw&r=0");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 4,
                column: "photo_url",
                value: "https://th.bing.com/th/id/OIP.bw6h6Chq7Hz65Js0ZmHVEQHaEJ?rs=1&pid=ImgDetMain");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 5,
                column: "photo_url",
                value: "https://cdn.motor1.com/images/mgl/zOXX4/s1/2021-toyota-tacoma-trd-off-road-driving-notes.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 1,
                column: "photo_url",
                value: "");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 2,
                column: "photo_url",
                value: "");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 3,
                column: "photo_url",
                value: "");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 4,
                column: "photo_url",
                value: "");

            migrationBuilder.UpdateData(
                table: "review",
                keyColumn: "review_id",
                keyValue: 5,
                column: "photo_url",
                value: "");
        }
    }
}
