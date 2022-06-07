using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGVAK_OnlineShop.DataAccess.Migrations
{
    public partial class addChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CoverTypeId",
                table: "Products",
                newName: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Products",
                newName: "CoverTypeId");

            migrationBuilder.AddColumn<int>(
                name: "BrandTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandTypeId",
                table: "Products",
                column: "BrandTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandTypeId",
                table: "Products",
                column: "BrandTypeId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
