using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2909b263-9f56-49fb-9f40-93d86ee3707a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb7718d-96d2-4ea5-9db8-dc44ef247b41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c268af3a-f9b7-4329-a532-0e56a937fcb5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fdadb7c-825b-4cea-903c-2d889ad03233", null, "Editor", "EDITOR" },
                    { "43256d41-2a40-4988-b8ae-0da73dd1386b", null, "Admin", "ADMIN" },
                    { "8e58580a-3bc5-448d-8734-f7d0ed01b31c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 24, 15, 52, 33, 791, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 24, 15, 52, 33, 791, DateTimeKind.Utc).AddTicks(5801));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fdadb7c-825b-4cea-903c-2d889ad03233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43256d41-2a40-4988-b8ae-0da73dd1386b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e58580a-3bc5-448d-8734-f7d0ed01b31c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2909b263-9f56-49fb-9f40-93d86ee3707a", null, "Admin", "ADMIN" },
                    { "adb7718d-96d2-4ea5-9db8-dc44ef247b41", null, "User", "USER" },
                    { "c268af3a-f9b7-4329-a532-0e56a937fcb5", null, "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 24, 15, 52, 13, 240, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 24, 15, 52, 13, 240, DateTimeKind.Utc).AddTicks(4130));
        }
    }
}
