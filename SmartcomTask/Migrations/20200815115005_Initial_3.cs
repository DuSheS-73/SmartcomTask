using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartcomTask.Migrations
{
    public partial class Initial_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersElements_Items_ItemID",
                table: "OrdersElements");

            migrationBuilder.DropIndex(
                name: "IX_OrdersElements_ItemID",
                table: "OrdersElements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c278d5-9291-4014-aa67-6e02ca552b4a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("2e3d5c25-19d9-4de7-b4f0-d4cc452ae184"), new Guid("c81d00d2-f76c-4e75-9774-3cad84ad926a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c81d00d2-f76c-4e75-9774-3cad84ad926a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e3d5c25-19d9-4de7-b4f0-d4cc452ae184"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c35ddc7c-77ee-448d-acca-c1f1c8de1edd"), "e9d0ed04-c6f9-4494-919c-475c94b9ae2e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("243fe3fd-3f5a-4f1a-b73c-39a7fee45762"), "722cc924-6622-4443-b085-c2a10054675d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("afebc95f-760c-4933-8bb6-578ef39ae993"), 0, "9af8f0ae-78b2-49a7-bccf-1d4e05c3fa27", null, "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKyYM+grlOKDVVzkTYqOCvoHRA+uFqi+oiiDLHC40Q6Kqu5M5hOgGuAk+5Hma18PPg==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("afebc95f-760c-4933-8bb6-578ef39ae993"), new Guid("c35ddc7c-77ee-448d-acca-c1f1c8de1edd") });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersElements_ItemID",
                table: "OrdersElements",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersElements_Items_ItemID",
                table: "OrdersElements",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersElements_Items_ItemID",
                table: "OrdersElements");

            migrationBuilder.DropIndex(
                name: "IX_OrdersElements_ItemID",
                table: "OrdersElements");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("243fe3fd-3f5a-4f1a-b73c-39a7fee45762"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("afebc95f-760c-4933-8bb6-578ef39ae993"), new Guid("c35ddc7c-77ee-448d-acca-c1f1c8de1edd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c35ddc7c-77ee-448d-acca-c1f1c8de1edd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("afebc95f-760c-4933-8bb6-578ef39ae993"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c81d00d2-f76c-4e75-9774-3cad84ad926a"), "c80ccba4-3078-4183-9e7f-c81c110103e2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e2c278d5-9291-4014-aa67-6e02ca552b4a"), "9496cf07-5963-4f00-ab30-f6f4e05a4801", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2e3d5c25-19d9-4de7-b4f0-d4cc452ae184"), 0, "d90fddb8-b192-497d-abf0-f4ad91880b79", null, "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENRGFsXOfQVVu2VOMkPDaXcBF4Wh8TiWHf3WiL1Tu/ZbAPCrx6EVSCLQE/F14dhr8w==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("2e3d5c25-19d9-4de7-b4f0-d4cc452ae184"), new Guid("c81d00d2-f76c-4e75-9774-3cad84ad926a") });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersElements_ItemID",
                table: "OrdersElements",
                column: "ItemID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersElements_Items_ItemID",
                table: "OrdersElements",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
