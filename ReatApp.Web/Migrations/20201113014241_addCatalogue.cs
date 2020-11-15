using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReatApp.Web.Migrations
{
    public partial class addCatalogue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointSaleImages");

            migrationBuilder.CreateTable(
                name: "CatalogueImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<Guid>(nullable: false),
                    PointSaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogueImages_PointSale_PointSaleId",
                        column: x => x.PointSaleId,
                        principalTable: "PointSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueImages_PointSaleId",
                table: "CatalogueImages",
                column: "PointSaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogueImages");

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
                name: "IX_PointSaleImages_PointSaleId",
                table: "PointSaleImages",
                column: "PointSaleId");
        }
    }
}
