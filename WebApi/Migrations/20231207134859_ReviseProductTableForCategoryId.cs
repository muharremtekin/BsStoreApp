using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class ReviseProductTableForCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30413358-a6fa-4adc-a084-7f732a6d9288", "2718e436-4bbe-4f06-ba6d-cbe1382579cc", "Editor", "EDITOR" },
                    { "6c7513d6-3315-4fe9-8367-fd1c1aa2ba06", "55e96580-5e9a-4ead-84da-7457e3859865", "Admin", "ADMIN" },
                    { "c46ce3df-88f2-4e0e-8564-d94edf54e009", "d14a8b49-cff8-4012-b30e-bf198b806057", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 7, 16, 48, 58, 734, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 7, 16, 48, 58, 734, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30413358-a6fa-4adc-a084-7f732a6d9288");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c7513d6-3315-4fe9-8367-fd1c1aa2ba06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c46ce3df-88f2-4e0e-8564-d94edf54e009");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "073cded9-012d-44bf-95f9-d0a56beb7a3c", "d9d10295-1df6-472d-8b30-14695d24b407", "User", "USER" },
                    { "6e3aa0b2-cd29-466e-8099-945efc9e3e22", "24db5353-cbef-449f-b508-26356ac0a4e1", "Editor", "EDITOR" },
                    { "7aa3a7a9-912d-4972-bf12-c3f2bc3ffadc", "bb5a8c08-3bde-4b6f-8c38-60c82ec5dfed", "Admin", "ADMIN" }
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Electronic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Electronic");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Book");
        }
    }
}
