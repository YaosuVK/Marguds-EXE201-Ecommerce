using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21524af7-eb2c-4a7a-8d14-dda80d5f6908");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45c48650-bd2d-44d8-8e26-44bbc48ff5ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c286942-94e6-47ae-9e38-cc90b9982acc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3c79b9-fe06-482b-9a78-b8f5c3128da8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d91533-25cf-42e1-9600-3f68836eb946");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00a92123-619e-4a36-a71b-510742d383f6", null, "Manager", "MANAGER" },
                    { "85ff1ee2-a232-479c-a047-b8e8cb697808", null, "Customer", "CUSTOMER" },
                    { "8ea0c24a-5621-4ab7-a7c7-a56fe98a71ee", null, "Staff", "STAFF" },
                    { "c28a4b9f-5934-45e6-bcd2-222b8f2bbf4e", null, "Admin", "ADMIN" },
                    { "f99d2e2f-b670-4178-8014-044653d6b8e0", null, "Shipper", "SHIPPER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00a92123-619e-4a36-a71b-510742d383f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ff1ee2-a232-479c-a047-b8e8cb697808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ea0c24a-5621-4ab7-a7c7-a56fe98a71ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28a4b9f-5934-45e6-bcd2-222b8f2bbf4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f99d2e2f-b670-4178-8014-044653d6b8e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21524af7-eb2c-4a7a-8d14-dda80d5f6908", null, "Staff", "STAFF" },
                    { "45c48650-bd2d-44d8-8e26-44bbc48ff5ed", null, "Customer", "CUSTOMER" },
                    { "6c286942-94e6-47ae-9e38-cc90b9982acc", null, "Shipper", "SHIPPER" },
                    { "de3c79b9-fe06-482b-9a78-b8f5c3128da8", null, "Manager", "MANAGER" },
                    { "e3d91533-25cf-42e1-9600-3f68836eb946", null, "Admin", "ADMIN" }
                });
        }
    }
}
