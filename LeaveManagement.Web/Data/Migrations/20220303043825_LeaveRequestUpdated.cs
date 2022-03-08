using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveRequestUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestComment",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestComment",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "RequestedDate",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "e9ae9df1-cf3f-4596-a6f3-249fd82ba31a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "1a88339e-d420-4b47-ad51-8a64eb88f774");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c500b270-08eb-4068-880b-2eabb075fe56", "AQAAAAEAACcQAAAAEEz0f4uwmQbB0n/Jc5gr3O9KR2DJSIyRmuz6U07CQZbuedQcZp0/YiE2ZKamaXoNOw==", "da85bf01-7e75-477f-9f49-33bb8cd7e7a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72633af4-497e-49ed-929d-b0f0ef55ea88", "AQAAAAEAACcQAAAAEC7LyeW7AO/d0x6tQt3cHO6XachEFQcOz/xWjMu1qGuiF+ZzoW+2OG2x4vdpIoYHFQ==", "cb4effe1-8972-4f87-8d7c-0870613d28b2" });
        }
    }
}
