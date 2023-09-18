using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_shop.Migrations
{
    public partial class ExtendOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Orders",
                type: "nvarchar(3000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2cc1ae-5d07-4adb-ba15-719725a5ca16",
                column: "ConcurrencyStamp",
                value: "20f343e1-4279-4eb1-8ce8-294353353823");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0fc0a4-46a0-406d-b164-216473011946",
                column: "ConcurrencyStamp",
                value: "89829600-fffe-4291-b989-43d1bb260e22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2846d2b2-81d9-4918-839d-b70acbf93ef2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af6a108-1f8f-4c8f-a271-a17f71464f49", "AQAAAAEAACcQAAAAEGAbxy0Wpxp9kbRH116biULWhbC6/GGIaN0jqcFpg14DhpnEA/oQ0eYFBXPJsCxqcg==", "5355450f-bc23-409d-952b-9cab6bd43a4a" });
        }
    }
}
