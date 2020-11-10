using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class addRestaurantsTableerror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Restaurants",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Restaurants");
        }
    }
}
