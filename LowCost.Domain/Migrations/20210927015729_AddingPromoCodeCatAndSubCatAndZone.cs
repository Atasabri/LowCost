using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCost.Domain.Migrations
{
    public partial class AddingPromoCodeCatAndSubCatAndZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "PromoCodes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategory_Id",
                table: "PromoCodes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zone_Id",
                table: "PromoCodes",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a38435da-ba99-4631-a218-c3638eae4102", "4fc5008f-645a-4a16-898b-edf72684dbee", "Admin", "ADMIN" },
                    { "61116502-615d-47ed-825b-f9c8cb803871", "af6b2722-4c7d-4721-9a5a-0ace30b9dd79", "Editor", "EDITOR" },
                    { "663ffcd5-6c07-45c3-be6a-966820dac07a", "7329680b-fd0c-42a1-b342-c06a5a80704e", "User", "USER" },
                    { "7e717afb-0a82-4d4d-a01b-91a3cde3b906", "b38e3747-295a-4fe1-b46b-a12994e0f19f", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CurrentLangauge", "DateOfBirth", "Email", "EmailConfirmed", "FCM", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Stock_Id", "TwoFactorEnabled", "UserName", "Zone_Id" },
                values: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", 0, 0.0, "b8e53923-429b-41f7-97e2-798f7eea0497", 1, null, "admin@gmail.com", false, null, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEFWGxFto58jzZ8/oCWGyIZ2pvk5aqgAwFVAtz/IT0KWuIVpcxLWePSnyeN5StNuYVA==", null, false, "616030a9-781e-4d67-bc58-4b8a9c6b58c4", null, false, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", "a38435da-ba99-4631-a218-c3638eae4102" });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_Category_Id",
                table: "PromoCodes",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_SubCategory_Id",
                table: "PromoCodes",
                column: "SubCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_Zone_Id",
                table: "PromoCodes",
                column: "Zone_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_Categories_Category_Id",
                table: "PromoCodes",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_SubCategories_SubCategory_Id",
                table: "PromoCodes",
                column: "SubCategory_Id",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_Zones_Zone_Id",
                table: "PromoCodes",
                column: "Zone_Id",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_Categories_Category_Id",
                table: "PromoCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_SubCategories_SubCategory_Id",
                table: "PromoCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_Zones_Zone_Id",
                table: "PromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_PromoCodes_Category_Id",
                table: "PromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_PromoCodes_SubCategory_Id",
                table: "PromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_PromoCodes_Zone_Id",
                table: "PromoCodes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61116502-615d-47ed-825b-f9c8cb803871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "663ffcd5-6c07-45c3-be6a-966820dac07a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e717afb-0a82-4d4d-a01b-91a3cde3b906");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a51922ac-de34-4272-8f45-d446fda3ecde", "a38435da-ba99-4631-a218-c3638eae4102" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38435da-ba99-4631-a218-c3638eae4102");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a51922ac-de34-4272-8f45-d446fda3ecde");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "SubCategory_Id",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "Zone_Id",
                table: "PromoCodes");

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
    }
}
