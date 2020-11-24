using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Interview_BasicCRUD.Migrations
{
    public partial class UpdateProduct_Add_DB_TRDAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DB_TRDAT",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DB_TRDAT",
                table: "Products");
        }
    }
}
