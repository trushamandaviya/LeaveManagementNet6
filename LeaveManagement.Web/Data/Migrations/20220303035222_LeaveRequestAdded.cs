using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveRequestAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "d264972f-c1a4-4632-8ac6-cf8fc18bf451");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "46a7844c-0255-4ff7-8b35-f59526e87c3c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d60dec9-3b74-4622-b5c2-ac55e3ed1aab", "AQAAAAEAACcQAAAAEAv72Cwbe8VsY/ZITF7Jt7Dw1e8IBN0DmDsg31MUHSaRc+gTJWKAZG5GJ1gQKoadlA==", "4b972a30-b6de-49dd-b690-3d100a3dc2fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c758b665-d33a-4709-a711-8b7bc4cbe38c", "AQAAAAEAACcQAAAAEIUf0FiMInQZ6ekD+RvVp1q0GFY/E4Qt//aQpspHRh/zxh+66+AnOUTUY2oZseGAoA==", "a1f33332-4aff-4348-ae5e-97896c0c60c9" });
        }
    }
}
