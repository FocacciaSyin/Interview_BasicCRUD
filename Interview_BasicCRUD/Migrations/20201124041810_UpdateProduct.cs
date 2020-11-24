using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_BasicCRUD.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DB_CRUSR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DB_TRUSR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DB_UPDAT",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DB_CRUSR",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DB_TRUSR",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DB_UPDAT",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }
    }
}
