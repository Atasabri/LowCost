using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingMaxQuantityPerOrderinProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c4ffaad-856d-4f58-8bcc-297063295e60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "539de8ee-abb8-4fac-a02c-0e36ad9aeebd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54963e64-2a4a-4cea-827f-f619c87cf7dc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "571696f3-7077-45f7-88e3-6695a1792ba5", "65681a32-a07f-4179-9c69-fc8d544e7af1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65681a32-a07f-4179-9c69-fc8d544e7af1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "571696f3-7077-45f7-88e3-6695a1792ba5");

            migrationBuilder.AddColumn<int>(
                name: "MaxQuantityPerOrder",
                table: "Prices",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d77f528-bb98-4e96-bc95-a39c3f836351", "d11f460d-0a0b-4817-883e-f345ddf2101f", "Admin", "ADMIN" },
                    { "8035afc5-9b19-43dc-a981-2cb8fb4246d8", "d40a5f90-ab31-4fda-a5b5-e58c34d27185", "Editor", "EDITOR" },
                    { "29f0c83b-d45a-4405-b7ce-e504cbe4b414", "2bfec252-34d9-40ba-8748-c21d4b2f0d51", "User", "USER" },
                    { "ec9be75a-ab3b-4b05-8f68-954b5a48f014", "04d8209b-0aef-4939-8d84-a94789a6fe15", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "9c703adc-8b2a-4108-80c0-297c1ebff45c", 0, 0.0, "fe03a2e4-e8e9-4485-9c29-e354363be3df", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJiFtUIAHEf4ZyvcdIvHZVmrfGyIQqErwLRvQLgA5NjKoYanVvk3AMcI/vcR2cl8dQ==", null, false, "21b0231f-565d-4c57-a574-75ba113f0301", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "9c703adc-8b2a-4108-80c0-297c1ebff45c", "2d77f528-bb98-4e96-bc95-a39c3f836351" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f0c83b-d45a-4405-b7ce-e504cbe4b414");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8035afc5-9b19-43dc-a981-2cb8fb4246d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9be75a-ab3b-4b05-8f68-954b5a48f014");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9c703adc-8b2a-4108-80c0-297c1ebff45c", "2d77f528-bb98-4e96-bc95-a39c3f836351" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d77f528-bb98-4e96-bc95-a39c3f836351");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c703adc-8b2a-4108-80c0-297c1ebff45c");

            migrationBuilder.DropColumn(
                name: "MaxQuantityPerOrder",
                table: "Prices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65681a32-a07f-4179-9c69-fc8d544e7af1", "4c9ae4af-8763-4134-9487-1a82258d3471", "Admin", "ADMIN" },
                    { "54963e64-2a4a-4cea-827f-f619c87cf7dc", "5afb7a7d-247d-4a11-a949-5fa743b088c8", "Editor", "EDITOR" },
                    { "4c4ffaad-856d-4f58-8bcc-297063295e60", "e0d72907-a64e-4e24-88e6-e1576e19efad", "User", "USER" },
                    { "539de8ee-abb8-4fac-a02c-0e36ad9aeebd", "6c99f9ef-4e55-44e8-a4ca-6b4537a4e532", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "571696f3-7077-45f7-88e3-6695a1792ba5", 0, 0.0, "ecfcdf98-a571-4bc7-9dc0-b7331cf86a21", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIns+gx0YYlhbPjnmNfLgh2IFbyjmbW7dHvKk1BMRh0//BOnEdalo6FcTEmtIvGUuA==", null, false, "d68de8fc-5495-4046-8ec1-0a014493091a", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "571696f3-7077-45f7-88e3-6695a1792ba5", "65681a32-a07f-4179-9c69-fc8d544e7af1" });
        }
    }
}
