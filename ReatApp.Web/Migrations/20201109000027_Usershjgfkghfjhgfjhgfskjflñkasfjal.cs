using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class Usershjgfkghfjhgfjhgfskjflñkasfjal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantImages_RestaurantId",
                table: "RestaurantImages");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImages_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
