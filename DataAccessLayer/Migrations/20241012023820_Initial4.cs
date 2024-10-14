using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "b41aefb3-e403-453a-b050-1cc3cdee3840", null, "Customer", "CUSTOMER" },
                    { "d8d5a77f-33ab-48eb-a600-dc7b5e67a7fe", null, "Staff", "STAFF" },
                    { "e5aaf111-9849-4182-b75f-80b4c7f580e0", null, "Manager", "MANAGER" },
                    { "fbc92659-fed7-4ca9-993f-b0054c53a14c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b41aefb3-e403-453a-b050-1cc3cdee3840");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d5a77f-33ab-48eb-a600-dc7b5e67a7fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5aaf111-9849-4182-b75f-80b4c7f580e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbc92659-fed7-4ca9-993f-b0054c53a14c");

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
        }
    }
}
