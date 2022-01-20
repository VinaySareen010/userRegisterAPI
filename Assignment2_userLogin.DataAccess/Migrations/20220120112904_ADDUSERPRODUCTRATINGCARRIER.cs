using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class ADDUSERPRODUCTRATINGCARRIER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewsId",
                table: "UserProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProductRatings_ReviewsId",
                table: "UserProductRatings",
                column: "ReviewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductRatings_Reviews_ReviewsId",
                table: "UserProductRatings",
                column: "ReviewsId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductRatings_Reviews_ReviewsId",
                table: "UserProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserProductRatings_ReviewsId",
                table: "UserProductRatings");

            migrationBuilder.DropColumn(
                name: "ReviewsId",
                table: "UserProductRatings");
        }
    }
}
