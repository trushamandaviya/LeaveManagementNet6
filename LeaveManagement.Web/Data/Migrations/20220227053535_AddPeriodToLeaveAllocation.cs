using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "8436d76e-e64e-486d-b253-f6018ce7ab99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "616ce059-24df-416e-907c-850634632671");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8562058-117d-4813-8581-f8051eea5340", "AQAAAAEAACcQAAAAEFefEvi2rSyr8p0Qr2+nBHKcOMTFxBq0i11wFdrD7UeDeT1JmwKx2no5hbFX8hhwjQ==", "525be5c4-9263-45ce-8a08-ae29486e7171" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ec156d0-0fee-4fcf-88b8-25b0d92abe71", "AQAAAAEAACcQAAAAEKmYdmnKqxk/FG3LK2jZAM27hIr0oge3K0mwSub7BVVDIf3bcxLsgakVFEKKe8Y5/g==", "5ed4ccf3-8bd7-4287-81be-6b5eb33b2827" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "ae7addbf-fa25-49a4-a248-45c5d288f06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "8785b854-d13d-4876-8785-3a76f0bcea9d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ece398b-b2fb-4803-8ce9-7f5fd6e8d27e", "AQAAAAEAACcQAAAAEAlVt36fD6LoHn8fYIIGWVFAGn1BcRI+sDdXeCEsSHJsHGXPtmhHT+NM2klbcF+thg==", "10ea5a75-d459-44a0-8dd7-2c5645e15b28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1aba9c3-c8d6-439e-817a-9f32f8042e46", "AQAAAAEAACcQAAAAEMNP1FYdgxr7BsxIIV7wLB7kQNODijo2fw21f6Dv+IitsJRXGnN9RxpU99huCROVjQ==", "04818e4b-78fa-4216-b8fc-4bd72ae98139" });
        }
    }
}
