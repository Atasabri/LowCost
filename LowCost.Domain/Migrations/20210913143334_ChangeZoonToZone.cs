using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class ChangeZoonToZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Zoons_Zoon_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Zoons");

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
                name: "Zoon_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Zoon_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Zone_Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Zone_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zones",
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
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Stocks_Stock_Id",
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
                    { "d0a5784f-d340-4424-b8d9-2f4d84c887d4", "6fec874f-8a1e-4d69-b040-6cd7ee8eaa04", "Admin", "ADMIN" },
                    { "5a31de33-cee7-4591-8862-c719dd4ef86e", "28242488-5286-48f6-bacc-8d3aa033932e", "Editor", "EDITOR" },
                    { "4cfd8f4d-ce8c-4b8e-8d5e-2972f37c7da2", "22090956-e36a-49de-ad57-ca67ac4a2cd1", "User", "USER" },
                    { "4ddce002-e2c2-4672-911d-02240133f7c7", "9afd4d06-4422-4c83-83a6-b05c8e60214a", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f", 0, "5bfd1ffa-252c-445f-b4ed-a1e54bf739d2", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGguT8rUhQfwkhYCS/HWMTVhet3qJlO9VJez2ia8cCaWwzUFU+XYgYVo8Om/oSGOJw==", null, false, "83c0acf4-16ec-4111-b84b-5fdb455b7b5a", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "69a1abd0-178e-446e-afe9-a6eb8dd7ba0f", "d0a5784f-d340-4424-b8d9-2f4d84c887d4" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Zone_Id",
                table: "AspNetUsers",
                column: "Zone_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Stock_Id",
                table: "Zones",
                column: "Stock_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Zones_Zone_Id",
                table: "AspNetUsers",
                column: "Zone_Id",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Zones_Zone_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Zone_Id",
                table: "AspNetUsers");

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
                name: "Zone_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Zone_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Zoon_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Zoon_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zoons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_AR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock_Id = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_AspNetUsers_Zoon_Id",
                table: "AspNetUsers",
                column: "Zoon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zoons_Stock_Id",
                table: "Zoons",
                column: "Stock_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Zoons_Zoon_Id",
                table: "AspNetUsers",
                column: "Zoon_Id",
                principalTable: "Zoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
