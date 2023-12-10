using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2381f744-674c-4a7c-8e32-010f4ce0bbdc", "f86b05b1-a5b4-4cf0-9c79-c3807dfd03fb", "Admin", "ADMIN" },
                    { "34e530a9-8f65-48eb-a177-5d78177f6ec6", "12fc1988-e6a2-4711-a417-ceef37b47940", "Editor", "EDITOR" },
                    { "f980bdb0-bfdd-453e-9fbe-1eb02ce976b4", "303a30d8-4748-45d9-b52c-683a72b4e745", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 16, 13, 24, 20, 180, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 16, 13, 24, 20, 180, DateTimeKind.Local).AddTicks(5858));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2381f744-674c-4a7c-8e32-010f4ce0bbdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34e530a9-8f65-48eb-a177-5d78177f6ec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f980bdb0-bfdd-453e-9fbe-1eb02ce976b4");

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 16, 13, 14, 51, 422, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 11, 16, 13, 14, 51, 422, DateTimeKind.Local).AddTicks(3913));
        }
    }
}
