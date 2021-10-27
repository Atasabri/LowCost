using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessLowCostOffer",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e7778a81-ba74-4e7c-b291-75274db98efa", "6e2543ef-318f-4ea5-9178-556875678714", "Admin", "ADMIN" },
                    { "9cfd78bf-798d-474c-b469-be602f5111cd", "0fa4dd49-27f7-4cf3-82b3-e7fdcf62e763", "Editor", "EDITOR" },
                    { "a7ffbb7d-0493-46e7-a96f-223220c6a8c6", "8b79da6c-c161-4478-b381-fe29b2c748b3", "User", "USER" },
                    { "1cece0a6-06a4-4da9-b762-8c3dcb98b471", "903eb347-dc47-464e-98e2-302e82e7b85d", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LastAccessLowCostOffer", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "30616a26-7162-4b31-8432-c0fcf3da2e52", 0, 0.0, "eb13895a-3e22-4c83-aec1-7980fa77b612", 1, null, "admin@gmail.com", false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDyOscxf8sfBCFoSkR0rcvBbwSDhdLOkRSUybExvPSH2a2dxyHL3RaGK58qSXA7xtQ==", null, false, "43c49e2c-db74-4951-a937-dab4765ed2cb", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "30616a26-7162-4b31-8432-c0fcf3da2e52", "e7778a81-ba74-4e7c-b291-75274db98efa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cece0a6-06a4-4da9-b762-8c3dcb98b471");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cfd78bf-798d-474c-b469-be602f5111cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7ffbb7d-0493-46e7-a96f-223220c6a8c6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "30616a26-7162-4b31-8432-c0fcf3da2e52", "e7778a81-ba74-4e7c-b291-75274db98efa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7778a81-ba74-4e7c-b291-75274db98efa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30616a26-7162-4b31-8432-c0fcf3da2e52");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastAccessLowCostOffer",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessOffers",
                table: "AspNetUsers",
                type: "datetime2",
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
    }
}
