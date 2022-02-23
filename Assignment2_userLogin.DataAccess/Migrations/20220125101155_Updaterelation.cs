using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class Updaterelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewsComments_Reviews_ReviewsId",
                table: "ReviewsComments");

            migrationBuilder.DropIndex(
                name: "IX_ReviewsComments_ReviewsId",
                table: "ReviewsComments");

            migrationBuilder.DropColumn(
                name: "ReviewsId",
                table: "ReviewsComments");

            migrationBuilder.AddColumn<int>(
                name: "ReviewRatingId",
                table: "ProductUserReviewProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCommentId",
                table: "ProductUserReviewProductRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReviewRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRatings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUserReviewProductRatings_ReviewRatingId",
                table: "ProductUserReviewProductRatings",
                column: "ReviewRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUserReviewProductRatings_ReviewsCommentId",
                table: "ProductUserReviewProductRatings",
                column: "ReviewsCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUserReviewProductRatings_ReviewRatings_ReviewRatingId",
                table: "ProductUserReviewProductRatings",
                column: "ReviewRatingId",
                principalTable: "ReviewRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUserReviewProductRatings_ReviewsComments_ReviewsCommentId",
                table: "ProductUserReviewProductRatings",
                column: "ReviewsCommentId",
                principalTable: "ReviewsComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUserReviewProductRatings_ReviewRatings_ReviewRatingId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUserReviewProductRatings_ReviewsComments_ReviewsCommentId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropTable(
                name: "ReviewRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductUserReviewProductRatings_ReviewRatingId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductUserReviewProductRatings_ReviewsCommentId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ReviewRatingId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropColumn(
                name: "ReviewsCommentId",
                table: "ProductUserReviewProductRatings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "ReviewsId",
                table: "ReviewsComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsComments_ReviewsId",
                table: "ReviewsComments",
                column: "ReviewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewsComments_Reviews_ReviewsId",
                table: "ReviewsComments",
                column: "ReviewsId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
