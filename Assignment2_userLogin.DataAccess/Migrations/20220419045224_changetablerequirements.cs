using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class changetablerequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalOrders_OrderDetails_OrderDetailsId",
                table: "FinalOrders");

            migrationBuilder.DropIndex(
                name: "IX_FinalOrders_OrderDetailsId",
                table: "FinalOrders");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "FinalOrders");

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_OrderDetailId",
                table: "FinalOrders",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalOrders_OrderDetails_OrderDetailId",
                table: "FinalOrders",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalOrders_OrderDetails_OrderDetailId",
                table: "FinalOrders");

            migrationBuilder.DropIndex(
                name: "IX_FinalOrders_OrderDetailId",
                table: "FinalOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "FinalOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_OrderDetailsId",
                table: "FinalOrders",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalOrders_OrderDetails_OrderDetailsId",
                table: "FinalOrders",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
