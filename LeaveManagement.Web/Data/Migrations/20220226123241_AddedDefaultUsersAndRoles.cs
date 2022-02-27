using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29bfe79f-7b48-4162-8259-a7055793900e", "ae7addbf-fa25-49a4-a248-45c5d288f06f", "Administrator", "ADMINISTRATOR" },
                    { "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae", "8785b854-d13d-4876-8785-3a76f0bcea9d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FristName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29bfe99f-7b48-4162-8259-c7055793300e", 0, "4ece398b-b2fb-4803-8ce9-7f5fd6e8d27e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEAlVt36fD6LoHn8fYIIGWVFAGn1BcRI+sDdXeCEsSHJsHGXPtmhHT+NM2klbcF+thg==", null, false, "10ea5a75-d459-44a0-8dd7-2c5645e15b28", null, false, "admin@localhost.com" },
                    { "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae", 0, "e1aba9c3-c8d6-439e-817a-9f32f8042e46", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEMNP1FYdgxr7BsxIIV7wLB7kQNODijo2fw21f6Dv+IitsJRXGnN9RxpU99huCROVjQ==", null, false, "04818e4b-78fa-4216-b8fc-4bd72ae98139", null, false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29bfe79f-7b48-4162-8259-a7055793900e", "29bfe99f-7b48-4162-8259-c7055793300e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae", "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29bfe79f-7b48-4162-8259-a7055793900e", "29bfe99f-7b48-4162-8259-c7055793300e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae", "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae");
        }
    }
}
