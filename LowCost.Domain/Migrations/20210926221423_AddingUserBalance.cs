using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingUserBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fb09269-d48f-4c82-82fc-206da75e7efd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eac20ce-9b88-44c1-8950-6a28af4a40a7");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e225b404-f94f-423a-9061-2ea9542811de", "ef01ec36-1d5d-4585-93eb-a965d7670f1c", "Admin", "ADMIN" },
                    { "dda8a2aa-b5cd-4821-97a1-54188bc320d7", "2890573e-b699-40f2-9f64-85a6d22ee6d4", "Editor", "EDITOR" },
                    { "6389f413-329a-4e4e-abe7-7266c2c69b05", "2d5caaca-caed-4657-ae22-47eb393fc1c1", "User", "USER" },
                    { "da4414b1-18a3-406f-97a5-59a0c3f2c88f", "413c407f-85c4-4dc7-a16f-1314c1b149e5", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "4a592376-1d4b-4b2c-aa52-f9f22a85d2fe", 0, 0.0, "fd11a7bd-09b4-4b7f-bde2-13986b19025b", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEOv54Qh9VGXfbO5iht+2uUDcpvZ15w6ZgvP9tGuY09wd5ofv4Gm/c80OOxWdCAPzrQ==", null, false, "c16fd922-eefa-45be-94c3-65cc23813f87", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4a592376-1d4b-4b2c-aa52-f9f22a85d2fe", "e225b404-f94f-423a-9061-2ea9542811de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6389f413-329a-4e4e-abe7-7266c2c69b05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da4414b1-18a3-406f-97a5-59a0c3f2c88f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda8a2aa-b5cd-4821-97a1-54188bc320d7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4a592376-1d4b-4b2c-aa52-f9f22a85d2fe", "e225b404-f94f-423a-9061-2ea9542811de" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e225b404-f94f-423a-9061-2ea9542811de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a592376-1d4b-4b2c-aa52-f9f22a85d2fe");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

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
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0eac20ce-9b88-44c1-8950-6a28af4a40a7", "4fb09269-d48f-4c82-82fc-206da75e7efd" });
        }
    }
}
