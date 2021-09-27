using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingPromoCodeFreeDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61116502-615d-47ed-825b-f9c8cb803871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "663ffcd5-6c07-45c3-be6a-966820dac07a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e717afb-0a82-4d4d-a01b-91a3cde3b906");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", "a38435da-ba99-4631-a218-c3638eae4102" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38435da-ba99-4631-a218-c3638eae4102");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a51922ac-de34-4272-8f45-d446fda3ecde");

            migrationBuilder.AddColumn<bool>(
                name: "FreeDelivery",
                table: "PromoCodes",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FreeDelivery",
                table: "PromoCodes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a38435da-ba99-4631-a218-c3638eae4102", "4fc5008f-645a-4a16-898b-edf72684dbee", "Admin", "ADMIN" },
                    { "61116502-615d-47ed-825b-f9c8cb803871", "af6b2722-4c7d-4721-9a5a-0ace30b9dd79", "Editor", "EDITOR" },
                    { "663ffcd5-6c07-45c3-be6a-966820dac07a", "7329680b-fd0c-42a1-b342-c06a5a80704e", "User", "USER" },
                    { "7e717afb-0a82-4d4d-a01b-91a3cde3b906", "b38e3747-295a-4fe1-b46b-a12994e0f19f", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", 0, 0.0, "b8e53923-429b-41f7-97e2-798f7eea0497", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEFWGxFto58jzZ8/oCWGyIZ2pvk5aqgAwFVAtz/IT0KWuIVpcxLWePSnyeN5StNuYVA==", null, false, "616030a9-781e-4d67-bc58-4b8a9c6b58c4", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", "a38435da-ba99-4631-a218-c3638eae4102" });
        }
    }
}
