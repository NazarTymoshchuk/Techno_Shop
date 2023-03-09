using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    public partial class SystemBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "SystemBlockId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemBlocks", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SystemBlocks_SystemBlockId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SystemBlocks");

            migrationBuilder.DropIndex(
                name: "IX_Products_SystemBlockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SystemBlockId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Phone" },
                    { 3, "PC" },
                    { 4, "Headphones" },
                    { 5, "Accessories" },
                    { 6, "Accoustic System" }
                });
        }
    }
}
