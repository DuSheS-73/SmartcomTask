using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartcomTask.Migrations
{
    public partial class Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ItemID",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9fe757fa-927f-46fc-8c05-379490553cd1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("71280e47-ca39-477f-9a82-c7e2fc2c6186"), new Guid("b74b9078-4ec8-441c-9ed0-d62d3800012f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b74b9078-4ec8-441c-9ed0-d62d3800012f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71280e47-ca39-477f-9a82-c7e2fc2c6186"));

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
                name: "IX_ShoppingCartItems_ItemID",
                table: "ShoppingCartItems",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ItemID",
                table: "ShoppingCartItems");

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
                values: new object[] { new Guid("b74b9078-4ec8-441c-9ed0-d62d3800012f"), "189067c7-265e-44c2-b03d-36c0172997d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9fe757fa-927f-46fc-8c05-379490553cd1"), "632be5ac-7969-447a-ad96-3afc29e585ae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("71280e47-ca39-477f-9a82-c7e2fc2c6186"), 0, "76776a7d-c18a-486b-9b3a-79d6d56f1954", null, "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFXAzczDeT5sjQtZ8NuvznLGyR4ZsDvjucD4IP3QFHSu9eIVN8YFF+ZSHdqBIhyYhA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("71280e47-ca39-477f-9a82-c7e2fc2c6186"), new Guid("b74b9078-4ec8-441c-9ed0-d62d3800012f") });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ItemID",
                table: "ShoppingCartItems",
                column: "ItemID",
                unique: true);
        }
    }
}
