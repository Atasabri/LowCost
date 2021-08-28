using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingOrderKeyToCategoryAndBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0935e7b0-9b36-4db9-907f-e6848da605bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "485eeac1-3cfd-4f70-a7d0-c166d0729c4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e98345de-8262-4ddf-975f-82bfddc6e9e8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "aeb7f238-ce68-447c-8015-708d2ba5aecc", "63ba7a05-9239-418b-a31a-6d5482bd7d8d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ba7a05-9239-418b-a31a-6d5482bd7d8d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aeb7f238-ce68-447c-8015-708d2ba5aecc");

            migrationBuilder.AddColumn<int>(
                name: "OrderKey",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderKey",
                table: "Brands",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "551436ee-a9f7-49bc-8ebd-e190cbc482d5", "41b46040-ab03-47f5-8175-90591def35b5", "Admin", "ADMIN" },
                    { "1ae2e44e-b613-406f-b49e-a782ebfb76fd", "a8a5175b-7385-4f26-b2ec-96da4ad42d17", "Editor", "EDITOR" },
                    { "cbd73f89-0d94-45e3-ac89-e600249e3205", "a3390b1d-758e-49d9-adbb-e69333af655c", "User", "USER" },
                    { "4486ec40-d241-4b3f-a4d0-3bdfb73e3eee", "2a22d757-e9c6-463a-a5f5-eea1b123b22c", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f771226d-d6cd-408c-8d16-de75a455108c", 0, "dd267e2a-8c80-401f-b152-c2454c698f8a", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIePcXrf9hybIxepb4BKBn5akOMo0mLPCZQEZmG4fuV9D2/53j1/XHaPTJ/ZhRM93g==", null, false, "cf83f75d-7944-4c7c-97e8-5c056b45866a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f771226d-d6cd-408c-8d16-de75a455108c", "551436ee-a9f7-49bc-8ebd-e190cbc482d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae2e44e-b613-406f-b49e-a782ebfb76fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4486ec40-d241-4b3f-a4d0-3bdfb73e3eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbd73f89-0d94-45e3-ac89-e600249e3205");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f771226d-d6cd-408c-8d16-de75a455108c", "551436ee-a9f7-49bc-8ebd-e190cbc482d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "551436ee-a9f7-49bc-8ebd-e190cbc482d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f771226d-d6cd-408c-8d16-de75a455108c");

            migrationBuilder.DropColumn(
                name: "OrderKey",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "OrderKey",
                table: "Brands");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63ba7a05-9239-418b-a31a-6d5482bd7d8d", "aa4468ca-9a80-4276-a826-8c16f71532fe", "Admin", "ADMIN" },
                    { "0935e7b0-9b36-4db9-907f-e6848da605bd", "404e5bc0-ddb2-4b38-b74a-448db98b47a3", "Editor", "EDITOR" },
                    { "485eeac1-3cfd-4f70-a7d0-c166d0729c4e", "3e4978bd-f0a9-4060-9c96-32638be8d726", "User", "USER" },
                    { "e98345de-8262-4ddf-975f-82bfddc6e9e8", "722e28a6-cbdb-40a7-abbd-6ad65fbcb6cc", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aeb7f238-ce68-447c-8015-708d2ba5aecc", 0, "9dd12b1e-9cd1-4613-ad02-c87fbc43c205", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEFM7GxDiPI4O80lQVRsBWDwCmM2xvtotsmMMxPi4JzF2WXI7uqA9jwTWFM3iB0vTXw==", null, false, "134f6f73-8617-4f4f-bc48-acc61b066ebf", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "aeb7f238-ce68-447c-8015-708d2ba5aecc", "63ba7a05-9239-418b-a31a-6d5482bd7d8d" });
        }
    }
}
