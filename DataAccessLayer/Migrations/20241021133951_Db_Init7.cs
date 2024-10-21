using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0980a198-e2b9-4708-ab48-75ee3036f4e9", null, "Admin", "ADMIN" },
                    { "435236b4-952c-4685-9f9b-a511fb32c484", null, "Customer", "CUSTOMER" },
                    { "8b82bc41-a6ad-40f1-8e06-89dcb49caeec", null, "Manager", "MANAGER" },
                    { "9911cad7-c8a7-48d9-9e71-17d3342c06aa", null, "Staff", "STAFF" },
                    { "eb4b2f73-8ccf-44ec-8280-96997f902b56", null, "Shipper", "SHIPPER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0980a198-e2b9-4708-ab48-75ee3036f4e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "435236b4-952c-4685-9f9b-a511fb32c484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b82bc41-a6ad-40f1-8e06-89dcb49caeec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9911cad7-c8a7-48d9-9e71-17d3342c06aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb4b2f73-8ccf-44ec-8280-96997f902b56");

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
    }
}
