using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingZoonAndStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock_Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSize",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Zoon_Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zoon_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderSizeDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeFrom = table.Column<double>(nullable: false),
                    SizeTo = table.Column<double>(nullable: false),
                    Delivery = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSizeDelivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFollowingUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFollowingUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFollowingUsers_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFollowingUsers_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Stock_Id = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockProducts_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProducts_Stocks_Stock_Id",
                        column: x => x.Stock_Id,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zoons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Name_AR = table.Column<string>(nullable: false),
                    Stock_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zoons_Stocks_Stock_Id",
                        column: x => x.Stock_Id,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68f35c14-dad4-4a6a-9789-53bbcd649e86", "32a2a386-1ca0-48ac-8030-19937dda5673", "Admin", "ADMIN" },
                    { "4c5113d3-30a2-4d61-becf-c259af1bc2d3", "6ea92cfc-a2af-4f13-af2a-4bd95af3a4ff", "Editor", "EDITOR" },
                    { "5766ef6f-bb4b-4210-bb89-e4aced1dafc0", "f19c6cd1-a871-4f49-9838-5a818f025e93", "User", "USER" },
                    { "12d07f41-6f20-4556-91b6-045cea736acd", "dfea61ff-4628-49cb-82ab-c8b65ee59376", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zoon_Id" },
                values: new object[] { "3dd9c0a7-4bc9-441e-baa4-e06f46dad9f8", 0, "ee7b7913-280c-4a0c-909b-45b7b6df485b", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENqlm4aflwLcl9XD9Y4v6KLEusbCfNzzpKGu0euNs7jTHgkOMh/zKQ+L8KzRTjwQRw==", null, false, "2123df72-507e-44cc-a18e-1d812a588cff", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3dd9c0a7-4bc9-441e-baa4-e06f46dad9f8", "68f35c14-dad4-4a6a-9789-53bbcd649e86" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Stock_Id",
                table: "AspNetUsers",
                column: "Stock_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Zoon_Id",
                table: "AspNetUsers",
                column: "Zoon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFollowingUsers_Product_Id",
                table: "ProductFollowingUsers",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFollowingUsers_User_Id",
                table: "ProductFollowingUsers",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_Product_Id",
                table: "StockProducts",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_Stock_Id",
                table: "StockProducts",
                column: "Stock_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zoons_Stock_Id",
                table: "Zoons",
                column: "Stock_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stocks_Stock_Id",
                table: "AspNetUsers",
                column: "Stock_Id",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Zoons_Zoon_Id",
                table: "AspNetUsers",
                column: "Zoon_Id",
                principalTable: "Zoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stocks_Stock_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Zoons_Zoon_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderSizeDelivery");

            migrationBuilder.DropTable(
                name: "ProductFollowingUsers");

            migrationBuilder.DropTable(
                name: "StockProducts");

            migrationBuilder.DropTable(
                name: "Zoons");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Stock_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Zoon_Id",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d07f41-6f20-4556-91b6-045cea736acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c5113d3-30a2-4d61-becf-c259af1bc2d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5766ef6f-bb4b-4210-bb89-e4aced1dafc0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3dd9c0a7-4bc9-441e-baa4-e06f46dad9f8", "68f35c14-dad4-4a6a-9789-53bbcd649e86" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68f35c14-dad4-4a6a-9789-53bbcd649e86");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dd9c0a7-4bc9-441e-baa4-e06f46dad9f8");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalSize",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Zoon_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Stock_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Zoon_Id",
                table: "AspNetUsers");

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
    }
}
