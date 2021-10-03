using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<string>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Money = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_User_Id",
                table: "WalletTransactions",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletTransactions");

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
    }
}
