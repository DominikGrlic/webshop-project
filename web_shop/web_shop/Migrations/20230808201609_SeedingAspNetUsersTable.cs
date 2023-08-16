using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_shop.Migrations
{
    public partial class SeedingAspNetUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2846d2b2-81d9-4918-839d-b70acbf93ef2", 0, "Duga Uvala 302", "4af6a108-1f8f-4c8f-a271-a17f71464f49", "admin@admin.com", false, "Admin", "Adminovski", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGAbxy0Wpxp9kbRH116biULWhbC6/GGIaN0jqcFpg14DhpnEA/oQ0eYFBXPJsCxqcg==", null, false, "5355450f-bc23-409d-952b-9cab6bd43a4a", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cd0fc0a4-46a0-406d-b164-216473011946", "2846d2b2-81d9-4918-839d-b70acbf93ef2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd0fc0a4-46a0-406d-b164-216473011946", "2846d2b2-81d9-4918-839d-b70acbf93ef2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2846d2b2-81d9-4918-839d-b70acbf93ef2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2cc1ae-5d07-4adb-ba15-719725a5ca16",
                column: "ConcurrencyStamp",
                value: "8e833d92-1976-4ebd-97a2-330ed40c9ccc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0fc0a4-46a0-406d-b164-216473011946",
                column: "ConcurrencyStamp",
                value: "83b0e19b-6a6b-40a9-99b9-1b8c0b35c73b");
        }
    }
}
