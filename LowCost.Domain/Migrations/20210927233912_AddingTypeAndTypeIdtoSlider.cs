using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingTypeAndTypeIdtoSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SliderType",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SliderTypeId",
                table: "Sliders",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "382d2560-4c42-46ad-b736-984a2b9dcc70", "e7cd4bb4-6f59-4ad9-95f1-6a49dae3032c", "Admin", "ADMIN" },
                    { "86185c86-c68f-4ec7-961a-770e996f373f", "5da85f6b-bb26-4b88-bac5-f415399a8407", "Editor", "EDITOR" },
                    { "030b71d8-1433-4138-8321-fa0e2c34623f", "49d50603-0445-48e8-bad4-17f18ec17f6e", "User", "USER" },
                    { "e647dfdb-549c-4274-9fe7-3a5fe6fa9715", "280cfa15-0ae2-49f0-b71a-395d21039d7f", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "1b9a7b93-c660-4f12-acf9-d6b8b8871b4d", 0, 0.0, "f99bbede-f0a8-47a4-8905-e4d0d5aced74", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMBwDWJnCWhmb8xnDan0WvHlGMgK9WrypJ7KFESsGbByktWDWn57pySp944P+1iRTg==", null, false, "4b86a012-3d0a-4c3b-b19a-a93eb697a23b", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1b9a7b93-c660-4f12-acf9-d6b8b8871b4d", "382d2560-4c42-46ad-b736-984a2b9dcc70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "030b71d8-1433-4138-8321-fa0e2c34623f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86185c86-c68f-4ec7-961a-770e996f373f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e647dfdb-549c-4274-9fe7-3a5fe6fa9715");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1b9a7b93-c660-4f12-acf9-d6b8b8871b4d", "382d2560-4c42-46ad-b736-984a2b9dcc70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382d2560-4c42-46ad-b736-984a2b9dcc70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9a7b93-c660-4f12-acf9-d6b8b8871b4d");

            migrationBuilder.DropColumn(
                name: "SliderType",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SliderTypeId",
                table: "Sliders");

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
    }
}
