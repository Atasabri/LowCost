using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingDeliveryToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cfd8f4d-ce8c-4b8e-8d5e-2972f37c7da2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ddce002-e2c2-4672-911d-02240133f7c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a31de33-cee7-4591-8862-c719dd4ef86e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f", "d0a5784f-d340-4424-b8d9-2f4d84c887d4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0a5784f-d340-4424-b8d9-2f4d84c887d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f");

            migrationBuilder.DropColumn(
                name: "Taxs",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "Delivery",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "Name" },
                values: new object[] { "Delivery", "Delivery" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d0fb31c2-7a3a-4335-9a1a-b0e66f061fd2", "4fe3dac3-abc7-4526-aad2-2719f970f2d4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "Taxs",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d0a5784f-d340-4424-b8d9-2f4d84c887d4", "6fec874f-8a1e-4d69-b040-6cd7ee8eaa04", "Admin", "ADMIN" },
                    { "5a31de33-cee7-4591-8862-c719dd4ef86e", "28242488-5286-48f6-bacc-8d3aa033932e", "Editor", "EDITOR" },
                    { "4cfd8f4d-ce8c-4b8e-8d5e-2972f37c7da2", "22090956-e36a-49de-ad57-ca67ac4a2cd1", "User", "USER" },
                    { "4ddce002-e2c2-4672-911d-02240133f7c7", "9afd4d06-4422-4c83-83a6-b05c8e60214a", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f", 0, "5bfd1ffa-252c-445f-b4ed-a1e54bf739d2", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGguT8rUhQfwkhYCS/HWMTVhet3qJlO9VJez2ia8cCaWwzUFU+XYgYVo8Om/oSGOJw==", null, false, "83c0acf4-16ec-4111-b84b-5fdb455b7b5a", null, false, "admin", null });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Key", "Name" },
                values: new object[] { "Tax", "Tax" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f", "d0a5784f-d340-4424-b8d9-2f4d84c887d4" });
        }
    }
}
