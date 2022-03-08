using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveRequestCommentUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RequestComment",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "58a4245a-cbcd-4a9c-a1b3-cbf815ec6301");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "2ec99d3d-0373-4604-a568-d717516269c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f52bab9b-ee58-4839-8fed-42f5a1bae725", "AQAAAAEAACcQAAAAENioND+UZKiNsO9A5x60yHo0lk6Hr5LR/85T5bTMWzn6miLgdDyEZoYJZDBaG8tnog==", "bac2ccb7-120a-4a8a-a5e1-97fa659c2b0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd4cbbae-0025-4694-9c22-86857c0dd35b", "AQAAAAEAACcQAAAAEF7jJ5MsgwvI7LjZttTj4TAEuu18ZmYemWgeYY8odGfNZeauKDqgo4A+PYE1EFuwng==", "878011ea-50f2-41ce-94c0-32b86088c522" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestComment",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "62d4f332-1e68-4b13-a109-1c255e476b39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "4c680aca-dc7b-4301-90de-bdbd655ed573");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dde2e0b7-392e-42b4-8e36-61d467a9b2c0", "AQAAAAEAACcQAAAAEPF+f0Ota6QGUHTlaLyYDWjxBEMC1QxJQbD+/NqZf+j1HyeroF7gj5wyCVvC0TntLw==", "9eda9f10-16a5-48e3-ac52-a72d7c1f34e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f251d55-3e41-4783-93fb-29795b3a3ff2", "AQAAAAEAACcQAAAAEKDkMCkIdfCrGyE7Vsr85xBnmpk+FxSaVu7usPxfRC3JyKeBVtBgigBlmkJtdCecdQ==", "152b5078-97a3-44b2-8fee-6b23e01b476f" });
        }
    }
}
