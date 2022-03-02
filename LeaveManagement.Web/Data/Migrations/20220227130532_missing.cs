using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class missing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe79f-7b48-4162-8259-a7055793900e",
                column: "ConcurrencyStamp",
                value: "9300e972-b245-45aa-9d3e-a4a23ca4829c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                column: "ConcurrencyStamp",
                value: "02cf751d-1b5b-4a16-94de-1d3ac2d31bbf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29bfe99f-7b48-4162-8259-c7055793300e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d101819-0de9-401b-b7dc-312ba6a709b1", "AQAAAAEAACcQAAAAEHgakp5jOAj7lox1tkDl7hRrx2TV0J27pZ6lWjKWMYXZ9trSmk7OkB7soEgqHE10hg==", "30727770-eaa9-4903-aadb-f861f70e0869" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1de263e-d7fa-4021-9323-dcaa007fe662", "AQAAAAEAACcQAAAAELSF+BAquiLgVw1+HLC5AdK08VCBVitCc1abcRQK0MNpKKIwARcPCKXZ4TmPCU1kwQ==", "084000c1-4c1a-48b7-b8ab-2a8e05b2b083" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
