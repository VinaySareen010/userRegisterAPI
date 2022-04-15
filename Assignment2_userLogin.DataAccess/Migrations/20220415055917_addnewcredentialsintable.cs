using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class addnewcredentialsintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "FinalOrders",
                newName: "TotalPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "FinalOrders",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
