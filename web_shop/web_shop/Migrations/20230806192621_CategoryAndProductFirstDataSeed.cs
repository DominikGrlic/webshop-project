using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_shop.Migrations
{
    public partial class CategoryAndProductFirstDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "Mesni proizvodi" },
                    { 2, null, null, "Mljecni proizvodi" },
                    { 3, null, null, "Voce" },
                    { 4, null, null, "Zitarice" },
                    { 5, null, null, "Riba" },
                    { 6, null, null, "Orasasti plodovi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "InStock", "Price", "Sku", "Title" },
                values: new object[,]
                {
                    { 100, "Svjeze banane", null, 64m, 3.99m, "B0900", "Banane" },
                    { 101, "Sitno mljevena zob", null, 32m, 1.99m, "Z1234", "Zob" },
                    { 102, "Bademovo mlijeko bez dodatnog secera", null, 27m, 6.50m, "BM0009", "Alpro bademovo mlijeko" },
                    { 103, "Komadici tune sa slanutkom i kuskusom", null, 64m, 3.99m, "R87878", "Riomare Tuna" },
                    { 104, "Prsut iz Drnisa", null, 64m, 3.99m, "M7767", "Vincek prsut" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 3, 100 },
                    { 2, 4, 101 },
                    { 3, 6, 102 },
                    { 4, 5, 103 },
                    { 5, 1, 104 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);
        }
    }
}
