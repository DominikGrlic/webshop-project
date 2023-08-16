using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_shop.Migrations
{
    public partial class SeedingAspNetRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c2cc1ae-5d07-4adb-ba15-719725a5ca16", "8e833d92-1976-4ebd-97a2-330ed40c9ccc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd0fc0a4-46a0-406d-b164-216473011946", "83b0e19b-6a6b-40a9-99b9-1b8c0b35c73b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2cc1ae-5d07-4adb-ba15-719725a5ca16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0fc0a4-46a0-406d-b164-216473011946");
        }
    }
}
