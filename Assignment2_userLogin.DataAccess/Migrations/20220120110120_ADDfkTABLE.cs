using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class ADDfkTABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserProductRatings_ProductRatingId",
                table: "UserProductRatings",
                column: "ProductRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductRatings_UserId",
                table: "UserProductRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductRatings_ProductRatings_ProductRatingId",
                table: "UserProductRatings",
                column: "ProductRatingId",
                principalTable: "ProductRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductRatings_Users_UserId",
                table: "UserProductRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductRatings_ProductRatings_ProductRatingId",
                table: "UserProductRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProductRatings_Users_UserId",
                table: "UserProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserProductRatings_ProductRatingId",
                table: "UserProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserProductRatings_UserId",
                table: "UserProductRatings");
        }
    }
}
