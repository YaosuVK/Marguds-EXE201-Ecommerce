using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fb2af06-0d65-4f75-b825-7b3a3a45a172");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7556fd4f-744d-4e08-b07c-890205ffaf23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f248b8-9637-4295-8f82-0fc463566634");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7920bc8-7a73-4a21-81f2-348284b1d368");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_AccountID",
                        column: x => x.AccountID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageBlog",
                columns: table => new
                {
                    ImageBlogsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBlog", x => x.ImageBlogsID);
                    table.ForeignKey(
                        name: "FK_ImageBlog_Blogs_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "467c24eb-04cb-4603-99c2-187a4dcd625d", null, "Customer", "CUSTOMER" },
                    { "9866ff13-5f1e-4bd8-af80-6ee96c8961dc", null, "Admin", "ADMIN" },
                    { "d3edd655-9ef0-4c1c-b61a-9ad39eae2d93", null, "Manager", "MANAGER" },
                    { "fc7c17a6-3e4d-4333-be1f-f3eef072cfcf", null, "Staff", "STAFF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AccountID",
                table: "Blogs",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBlog_BlogID",
                table: "ImageBlog",
                column: "BlogID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageBlog");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "467c24eb-04cb-4603-99c2-187a4dcd625d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9866ff13-5f1e-4bd8-af80-6ee96c8961dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3edd655-9ef0-4c1c-b61a-9ad39eae2d93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7c17a6-3e4d-4333-be1f-f3eef072cfcf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fb2af06-0d65-4f75-b825-7b3a3a45a172", null, "Customer", "CUSTOMER" },
                    { "7556fd4f-744d-4e08-b07c-890205ffaf23", null, "Admin", "ADMIN" },
                    { "c2f248b8-9637-4295-8f82-0fc463566634", null, "Staff", "STAFF" },
                    { "d7920bc8-7a73-4a21-81f2-348284b1d368", null, "Manager", "MANAGER" }
                });
        }
    }
}
