using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class AddProductIdToFavourite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_ProductId",
                table: "Favourites",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_ProductId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Favourites");
        }
    }
}
