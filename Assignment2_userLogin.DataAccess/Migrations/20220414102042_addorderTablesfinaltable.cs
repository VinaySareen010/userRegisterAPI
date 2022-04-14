using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class addorderTablesfinaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductComapnyAddress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCompany",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_DeliveryAddresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "DeliveryAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    OrderDetailsId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalOrders_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_OrderDetailsId",
                table: "FinalOrders",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_ProductId",
                table: "FinalOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeliveryAddressId",
                table: "OrderDetails",
                column: "DeliveryAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalOrders");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductComapnyAddress",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCompany",
                table: "Products");
        }
    }
}
