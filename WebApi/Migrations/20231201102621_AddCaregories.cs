using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddCaregories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07017cdc-8094-49cb-8c39-da7c489b8598");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96237db7-29c5-4f3b-80fa-59ccd7ecefbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6768c7-bcf9-4880-8d98-469b849dd375");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "073cded9-012d-44bf-95f9-d0a56beb7a3c", "d9d10295-1df6-472d-8b30-14695d24b407", "User", "USER" },
                    { "6e3aa0b2-cd29-466e-8099-945efc9e3e22", "24db5353-cbef-449f-b508-26356ac0a4e1", "Editor", "EDITOR" },
                    { "7aa3a7a9-912d-4972-bf12-c3f2bc3ffadc", "bb5a8c08-3bde-4b6f-8c38-60c82ec5dfed", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Life" },
                    { 3, "Style" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 1, 13, 26, 20, 993, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 1, 13, 26, 20, 993, DateTimeKind.Local).AddTicks(9831));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "073cded9-012d-44bf-95f9-d0a56beb7a3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e3aa0b2-cd29-466e-8099-945efc9e3e22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aa3a7a9-912d-4972-bf12-c3f2bc3ffadc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07017cdc-8094-49cb-8c39-da7c489b8598", "164aa50e-4b31-44d6-86dd-416c83433b62", "User", "USER" },
                    { "96237db7-29c5-4f3b-80fa-59ccd7ecefbd", "836c5fe9-bacc-484a-b04d-07c4650e020a", "Editor", "EDITOR" },
                    { "cd6768c7-bcf9-4880-8d98-469b849dd375", "9f36355b-890c-47c4-b02f-a1e5b576ecd0", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 24, 13, 31, 0, 761, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 24, 13, 31, 0, 761, DateTimeKind.Local).AddTicks(4809));
        }
    }
}
