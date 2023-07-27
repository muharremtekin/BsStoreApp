using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Description", "IsResolved", "ProductId", "ReportedAt" },
                values: new object[,]
                {
                    { 1, "Faulty product", false, 2, new DateTime(2023, 7, 24, 15, 41, 49, 634, DateTimeKind.Local).AddTicks(220) },
                    { 2, "Faulty product", false, 1, new DateTime(2023, 7, 24, 15, 41, 49, 634, DateTimeKind.Local).AddTicks(232) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EntityId", "ImageData", "Name" },
                values: new object[,]
                {
                    { 11, 1, new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, "image_1" },
                    { 12, 2, new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, "image_2" },
                    { 13, 3, new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, "image_3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Electronic", "Asus ZendBook", "Laptop", 999m },
                    { 2, "Electronic", "IPhone 14 Pro", "Phone", 999m },
                    { 3, "Book", "Clean Code", "Laptop", 100m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
