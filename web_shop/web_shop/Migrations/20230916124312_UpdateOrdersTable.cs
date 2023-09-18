using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_shop.Migrations
{
    public partial class UpdateOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2cc1ae-5d07-4adb-ba15-719725a5ca16",
                column: "ConcurrencyStamp",
                value: "a55f5303-0b58-41d5-a3ba-9407308a44be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0fc0a4-46a0-406d-b164-216473011946",
                column: "ConcurrencyStamp",
                value: "73226c36-ec6b-4c2c-bc12-392deae06f75");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2846d2b2-81d9-4918-839d-b70acbf93ef2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2681eb13-ae95-4ab6-84c7-f8a09cfdbf7f", "AQAAAAEAACcQAAAAEMz+Bu3Sz3RV5SqOBJOHny9elNLVViohkco8lFHy74JRTRLChzVn/jbVfhtV4GWSfg==", "5448b16a-75eb-4d7c-8803-68f98b8f83d0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2cc1ae-5d07-4adb-ba15-719725a5ca16",
                column: "ConcurrencyStamp",
                value: "4b558d0b-a376-41ed-b32c-99ecdcb9e908");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0fc0a4-46a0-406d-b164-216473011946",
                column: "ConcurrencyStamp",
                value: "8acb0f3d-a880-49ea-a818-f26a0f758767");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2846d2b2-81d9-4918-839d-b70acbf93ef2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a953f5a-03e6-4a34-a1fd-ed1d15b091e1", "AQAAAAEAACcQAAAAEJCrDCUwaSExsk7uDyMtv8cUHNqjVnR4nf3tXKtMvv0e6QZi1URYKfE7v3vWsX2CMg==", "02a0a118-12b1-42f0-ade1-5a038968db57" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
