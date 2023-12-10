using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
