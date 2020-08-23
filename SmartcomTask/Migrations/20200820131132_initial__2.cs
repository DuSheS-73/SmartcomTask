using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartcomTask.Migrations
{
    public partial class initial__2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c78faf-4128-42ff-aff6-c00cc6ab2ef4"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4b7e18de-80d2-46cc-93bd-963eacb21a43"), new Guid("c9fd7807-471d-46b2-8c36-28f9caf15014") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9fd7807-471d-46b2-8c36-28f9caf15014"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4b7e18de-80d2-46cc-93bd-963eacb21a43"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Orders",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c9fd7807-471d-46b2-8c36-28f9caf15014"), "2a701025-f0b5-4df8-86ff-9c9d1ad14882", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("84c78faf-4128-42ff-aff6-c00cc6ab2ef4"), "e448a183-0599-40b6-91b7-ea9cfe47af4d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4b7e18de-80d2-46cc-93bd-963eacb21a43"), 0, "658a0290-11db-44ad-aff6-736e1f9fbdbe", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKxCdAX1LccHVg1WVrRq3Xb84qGZqchebRMFrCGPTMdPRRXCEmIPRA6V4nWqSpk4kA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("4b7e18de-80d2-46cc-93bd-963eacb21a43"), new Guid("c9fd7807-471d-46b2-8c36-28f9caf15014") });
        }
    }
}
