using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartcomTask.Migrations
{
    public partial class Initial__55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e776a39-8d7f-4b1c-a604-f7e8306502af"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d3405634-19c5-4562-9311-ed7e84c36522"), new Guid("84a52946-11b8-41f0-841b-fd0c9b69add5") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("84a52946-11b8-41f0-841b-fd0c9b69add5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3405634-19c5-4562-9311-ed7e84c36522"));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Items",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("1089ef37-063a-493d-a2c7-a9b07d866afd"), "6773e182-7033-49df-8e19-1012a38467ca", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f76a4a21-aeeb-41b3-8d2c-c3fb5ba187e1"), "db8bf497-822f-4866-a348-8e5590bcf7d5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4dc1f2a8-3341-4975-b99a-59540154a0b2"), 0, "c4a124f2-79ea-435a-b712-f3017b1ffdbc", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJOarmUI1ND73PZlpwqoXHOJWI6gwmDLDQm/6FVjG1Uhrzi9P0Qq8EcnII9cSvxF5g==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("4dc1f2a8-3341-4975-b99a-59540154a0b2"), new Guid("1089ef37-063a-493d-a2c7-a9b07d866afd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f76a4a21-aeeb-41b3-8d2c-c3fb5ba187e1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4dc1f2a8-3341-4975-b99a-59540154a0b2"), new Guid("1089ef37-063a-493d-a2c7-a9b07d866afd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1089ef37-063a-493d-a2c7-a9b07d866afd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4dc1f2a8-3341-4975-b99a-59540154a0b2"));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("84a52946-11b8-41f0-841b-fd0c9b69add5"), "a5d59bde-5985-4774-b4e3-8d841eadc3e2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6e776a39-8d7f-4b1c-a604-f7e8306502af"), "811e22b7-7844-44dc-a4d8-888446fc522a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d3405634-19c5-4562-9311-ed7e84c36522"), 0, "e2bf5ea9-cc45-4696-97cb-2c30a343e9ba", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEH1ta6TG6SYLF7ZKlaJX7pgfDQ4Vq9tVugYL/u4k47klFY4beqYmlfyZnzxv1UOZZw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("d3405634-19c5-4562-9311-ed7e84c36522"), new Guid("84a52946-11b8-41f0-841b-fd0c9b69add5") });
        }
    }
}
