using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class EditUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b8c9726-4f9e-40be-9571-e2f7c786d294");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "794bd3dc-295c-46ef-b0ba-d15b72a0d8c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e08e6e-1c57-4d64-83c7-82948896292b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d0fb31c2-7a3a-4335-9a1a-b0e66f061fd2", "4fe3dac3-abc7-4526-aad2-2719f970f2d4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe3dac3-abc7-4526-aad2-2719f970f2d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0fb31c2-7a3a-4335-9a1a-b0e66f061fd2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fb09269-d48f-4c82-82fc-206da75e7efd", "c7114883-bf5d-4423-925e-eeb4b7515f41", "Admin", "ADMIN" },
                    { "b464e78d-3c32-4825-ad5e-55880ab15b9e", "0cfef534-9944-42c5-8083-163b10db1d14", "Editor", "EDITOR" },
                    { "aac67146-0d66-4ed8-9eb7-77602bb1b154", "126251a8-9208-48c7-a68a-02af1d3dac7c", "User", "USER" },
                    { "a5e71d12-d66a-4c62-b76d-1559f10cdc03", "5e7d1aba-e12d-4e14-8b0d-eb2440b411d9", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "0eac20ce-9b88-44c1-8950-6a28af4a40a7", 0, "d2fde4b7-c259-4aa9-bbd9-8e581a360190", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEL1hquNB+NzLN0D7wItRvYfsGmkXjsJ8UCDJvYRqs9godNdSNDkwn3m37oOU1pY9GA==", null, false, "7a8aee90-d3e8-4eb5-97cb-f43ae57d37be", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Name", "Type", "Value" },
                values: new object[] { 4, "PriceWithNoDelivery", "Price With No Delivery", 14, "500" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0eac20ce-9b88-44c1-8950-6a28af4a40a7", "4fb09269-d48f-4c82-82fc-206da75e7efd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e71d12-d66a-4c62-b76d-1559f10cdc03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac67146-0d66-4ed8-9eb7-77602bb1b154");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b464e78d-3c32-4825-ad5e-55880ab15b9e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0eac20ce-9b88-44c1-8950-6a28af4a40a7", "4fb09269-d48f-4c82-82fc-206da75e7efd" });

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fb09269-d48f-4c82-82fc-206da75e7efd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eac20ce-9b88-44c1-8950-6a28af4a40a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fe3dac3-abc7-4526-aad2-2719f970f2d4", "673cdddb-ace4-43f8-abaf-975d360bf069", "Admin", "ADMIN" },
                    { "5b8c9726-4f9e-40be-9571-e2f7c786d294", "b312369b-af0d-43b6-acfb-32cedd2f58d5", "Editor", "EDITOR" },
                    { "c2e08e6e-1c57-4d64-83c7-82948896292b", "b738903c-884a-4324-8017-78cc24b78387", "User", "USER" },
                    { "794bd3dc-295c-46ef-b0ba-d15b72a0d8c2", "a719c488-79d2-4be1-8d6b-841f59c7b6f3", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "d0fb31c2-7a3a-4335-9a1a-b0e66f061fd2", 0, "40d05200-8910-49fe-8d8f-16ec99648538", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEO8djPhcAk99826cDoMRyuthTEwKrKRo0MJREGyI1HBsCWxFExrM9tzSAwhuKlhwyA==", null, false, "3f1de014-5039-43d2-abca-1c67e8e07ee8", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d0fb31c2-7a3a-4335-9a1a-b0e66f061fd2", "4fe3dac3-abc7-4526-aad2-2719f970f2d4" });
        }
    }
}
