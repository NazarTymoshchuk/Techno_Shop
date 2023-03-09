using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class FixBag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSystemBlock_Products_productsId",
                table: "ProductSystemBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSystemBlock",
                table: "ProductSystemBlock");

            migrationBuilder.DropIndex(
                name: "IX_ProductSystemBlock_productsId",
                table: "ProductSystemBlock");

            migrationBuilder.RenameColumn(
                name: "productsId",
                table: "ProductSystemBlock",
                newName: "ProductsId");

            migrationBuilder.AlterColumn<int>(
                name: "SystemBlockId",
                table: "Favourites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Favourites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSystemBlock",
                table: "ProductSystemBlock",
                columns: new[] { "ProductsId", "SystemBlocksId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSystemBlock_SystemBlocksId",
                table: "ProductSystemBlock",
                column: "SystemBlocksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSystemBlock_Products_ProductsId",
                table: "ProductSystemBlock",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSystemBlock_Products_ProductsId",
                table: "ProductSystemBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSystemBlock",
                table: "ProductSystemBlock");

            migrationBuilder.DropIndex(
                name: "IX_ProductSystemBlock_SystemBlocksId",
                table: "ProductSystemBlock");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductSystemBlock",
                newName: "productsId");

            migrationBuilder.AlterColumn<int>(
                name: "SystemBlockId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSystemBlock",
                table: "ProductSystemBlock",
                columns: new[] { "SystemBlocksId", "productsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSystemBlock_productsId",
                table: "ProductSystemBlock",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Products_ProductId",
                table: "Favourites",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_SystemBlocks_SystemBlockId",
                table: "Favourites",
                column: "SystemBlockId",
                principalTable: "SystemBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSystemBlock_Products_productsId",
                table: "ProductSystemBlock",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
