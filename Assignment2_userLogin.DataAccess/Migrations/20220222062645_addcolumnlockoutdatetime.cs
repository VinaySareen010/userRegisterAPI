using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2_userLogin.DataAccess.Migrations
{
    public partial class addcolumnlockoutdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "count",
                table: "Users",
                newName: "Count");

            migrationBuilder.AddColumn<DateTime>(
                name: "LockOutDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockOutDateTime",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Users",
                newName: "count");
        }
    }
}
