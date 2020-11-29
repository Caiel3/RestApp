using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class AddOrderEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateConfirmed",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "bookings");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Restaurants",
                nullable: true);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateConfirmed",
                table: "bookings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "bookings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "bookings",
                nullable: true);
        }
    }
}
