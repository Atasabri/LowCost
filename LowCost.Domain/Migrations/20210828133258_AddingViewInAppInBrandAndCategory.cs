using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingViewInAppInBrandAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "ViewInApp",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewInApp",
                table: "Brands",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e2e65233-f3fc-44dc-bd7c-80134955c18c", "c1d3263a-97ab-45c7-815e-084067a3d5b3", "Admin", "ADMIN" },
                    { "3c36c10a-5527-473e-a6ae-8122c494564d", "d3d89a39-12ea-457c-9f14-fe5dbb5e5a9c", "Editor", "EDITOR" },
                    { "e3f43502-c00e-45c2-84df-b0b090dc977e", "563cce7c-6417-49f2-baec-e85b5e361b7d", "User", "USER" },
                    { "ef14ffdb-c3b3-4173-bd09-c8784656281d", "6315b0d6-6f98-4fa7-9c71-2d7964e60908", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b8c23845-216a-4e62-8d94-a7d6017d17d6", 0, "e401a0cc-2a6c-49c6-811e-a9e746b39abc", 1, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJzHPfDW+Y1CQLE2NAPc3a538SxrfXCYBWXQ451d+9icgoduQeFcEUQkE+Vc6uFR8A==", null, false, "eb4bfad9-1bc8-4810-8be6-346f2234c55b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b8c23845-216a-4e62-8d94-a7d6017d17d6", "e2e65233-f3fc-44dc-bd7c-80134955c18c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c36c10a-5527-473e-a6ae-8122c494564d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3f43502-c00e-45c2-84df-b0b090dc977e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef14ffdb-c3b3-4173-bd09-c8784656281d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b8c23845-216a-4e62-8d94-a7d6017d17d6", "e2e65233-f3fc-44dc-bd7c-80134955c18c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e65233-f3fc-44dc-bd7c-80134955c18c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8c23845-216a-4e62-8d94-a7d6017d17d6");

            migrationBuilder.DropColumn(
                name: "ViewInApp",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ViewInApp",
                table: "Brands");

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
    }
}
