using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class AddPiontSaleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "PointSale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PointSale",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
