using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class AddFacebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFacebook",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_UserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ImageFacebook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "AspNetUsers");
        }
    }
}
