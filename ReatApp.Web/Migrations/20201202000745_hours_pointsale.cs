using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class hours_pointsale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HourStart",
                table: "PointSale",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HourFinish",
                table: "PointSale",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HourStart",
                table: "PointSale",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HourFinish",
                table: "PointSale",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
