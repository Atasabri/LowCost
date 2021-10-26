using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class EditOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee339c7-3651-439a-bb23-dd3aae31bc1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eef5b46-a0e2-4924-9235-07e666f20e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd01a1f-56a4-4968-9e88-bbfaa8baec46");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e9a4d861-eb07-41cd-b8dd-ddae882b4b63", "3c85eed2-345a-4039-8d51-b3629aa475b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c85eed2-345a-4039-8d51-b3629aa475b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9a4d861-eb07-41cd-b8dd-ddae882b4b63");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Offers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Offers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessOffers",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87ef6326-ff0c-465a-9cb6-3ba00fbcdced", "3df63c33-53ed-4a5e-ac0c-9ff70f156db0", "Admin", "ADMIN" },
                    { "5ea884cb-89cf-40b0-8ffd-833780586892", "4765ab82-5dfc-4057-80ff-7f7f74a401e4", "Editor", "EDITOR" },
                    { "ecc2f802-0044-4889-a5ce-0b3436e7952e", "00cfc840-ac44-4bec-9d7e-c65268e0ae7e", "User", "USER" },
                    { "97c05468-e73a-4b8e-8dc9-5a202a940b87", "7c7a3cbb-3d82-414d-af12-6566b365e10f", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LastAccessOffers", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "c166e41c-3c9c-48eb-bc61-ed3bfa4cedf0", 0, 0.0, "e83876b6-9f2c-42dc-bdbb-65555af52dad", 1, null, "admin@gmail.com", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "ADMIN", "AQAAAAEAACcQAAAAELN7y+zDp8SNyp+o8D7xecHdAQZ2QTgFCvIM4B6iLcWz0aOEDRAXWtTkHWshp4LHxA==", null, false, "edf4aaff-5750-443b-ba51-a5f345f51a3f", null, false, "admin", null });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2021, 10, 26, 19, 8, 37, 392, DateTimeKind.Unspecified).AddTicks(7141));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c166e41c-3c9c-48eb-bc61-ed3bfa4cedf0", "87ef6326-ff0c-465a-9cb6-3ba00fbcdced" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea884cb-89cf-40b0-8ffd-833780586892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c05468-e73a-4b8e-8dc9-5a202a940b87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecc2f802-0044-4889-a5ce-0b3436e7952e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c166e41c-3c9c-48eb-bc61-ed3bfa4cedf0", "87ef6326-ff0c-465a-9cb6-3ba00fbcdced" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ef6326-ff0c-465a-9cb6-3ba00fbcdced");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c166e41c-3c9c-48eb-bc61-ed3bfa4cedf0");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LastAccessOffers",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c85eed2-345a-4039-8d51-b3629aa475b7", "7b688a26-bbc5-4dc0-adb2-ab5b2f6e13ac", "Admin", "ADMIN" },
                    { "9cd01a1f-56a4-4968-9e88-bbfaa8baec46", "82042ef7-ef65-423e-8df2-d4918c31e702", "Editor", "EDITOR" },
                    { "1ee339c7-3651-439a-bb23-dd3aae31bc1f", "67e29b1a-d110-4f72-bfd1-fa34ce034555", "User", "USER" },
                    { "8eef5b46-a0e2-4924-9235-07e666f20e00", "c396ff5a-df1a-4634-9abc-da558b0b66d0", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "e9a4d861-eb07-41cd-b8dd-ddae882b4b63", 0, 0.0, "cb29767a-7c7a-4db3-b06b-433e4c8cc17d", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJT2oiRa7ohWAxnSd/1+kEIy+QIUj5UeSls+zs1IYf191lYZLpYNiGS60PCUbw/6sw==", null, false, "cb982b2d-2ba5-4ba4-94d2-ff8325735bca", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e9a4d861-eb07-41cd-b8dd-ddae882b4b63", "3c85eed2-345a-4039-8d51-b3629aa475b7" });
        }
    }
}
