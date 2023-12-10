using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CategoriesAndProductsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0920929d-8d22-4f6d-8179-bce480d95c52", "78dcd6f4-33f4-45db-b8b7-68745cd0baef", "User", "USER" },
                    { "785be09a-1788-4ef3-8b2e-c8b00862a68e", "7b284656-859f-44b1-8f0d-cda3d51f51bc", "Admin", "ADMIN" },
                    { "ee5a9fb3-1f3f-45a6-98b0-42814ae3ec52", "f2ac2655-2d28-4f56-9d65-df95cf1cf4db", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 8, 16, 41, 14, 530, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportedAt",
                value: new DateTime(2023, 12, 8, 16, 41, 14, 530, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0920929d-8d22-4f6d-8179-bce480d95c52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "785be09a-1788-4ef3-8b2e-c8b00862a68e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee5a9fb3-1f3f-45a6-98b0-42814ae3ec52");

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
        }
    }
}
