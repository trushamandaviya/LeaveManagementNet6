using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class missingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "AspNetUsers",
                newName: "FirstName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "FristName");

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
    }
}
