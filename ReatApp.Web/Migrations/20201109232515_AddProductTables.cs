using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class AddProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantImages");

            migrationBuilder.CreateTable(
                name: "PointSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointSale_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointSaleImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<Guid>(nullable: false),
                    PointSaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointSaleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointSaleImages_PointSale_PointSaleId",
                        column: x => x.PointSaleId,
                        principalTable: "PointSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointSale_Name",
                table: "PointSale",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointSale_RestaurantId",
                table: "PointSale",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_PointSaleImages_PointSaleId",
                table: "PointSaleImages",
                column: "PointSaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointSaleImages");

            migrationBuilder.DropTable(
                name: "PointSale");

            migrationBuilder.CreateTable(
                name: "RestaurantImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImages", x => x.Id);
                });
        }
    }
}
