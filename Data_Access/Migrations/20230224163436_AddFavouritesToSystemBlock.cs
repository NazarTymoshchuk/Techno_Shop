using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class AddFavouritesToSystemBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SystemBlocks_SystemBlockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SystemBlockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SystemBlockId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SystemBlockId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductSystemBlock",
                columns: table => new
                {
                    SystemBlocksId = table.Column<int>(type: "int", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSystemBlock", x => new { x.SystemBlocksId, x.productsId });
                    table.ForeignKey(
                        name: "FK_ProductSystemBlock_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSystemBlock_SystemBlocks_SystemBlocksId",
                        column: x => x.SystemBlocksId,
                        principalTable: "SystemBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_SystemBlockId",
                table: "Favourites",
                column: "SystemBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSystemBlock_productsId",
                table: "ProductSystemBlock",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites");

            migrationBuilder.DropTable(
                name: "ProductSystemBlock");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_SystemBlockId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "SystemBlockId",
                table: "Favourites");

            migrationBuilder.AddColumn<int>(
                name: "SystemBlockId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SystemBlockId",
                table: "Products",
                column: "SystemBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SystemBlocks_SystemBlockId",
                table: "Products",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id");
        }
    }
}
