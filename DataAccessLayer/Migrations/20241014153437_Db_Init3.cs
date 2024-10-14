using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0de382ec-892b-4248-a822-5be048e3aa58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fd290ea-4902-40b9-b0f7-64264971c60f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6179602b-e1ee-4863-846e-a4dd511f6a79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1fe4b7f-2dc9-446c-a397-5435fde8f807");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62a4b7c-c2bd-4742-90ef-eab04166455a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f335b97-5b9c-4980-9f70-5a19c8047406", null, "Manager", "MANAGER" },
                    { "5a6bb717-824b-4298-b4de-b864c114ca40", null, "Shipper", "SHIPPER" },
                    { "63f061dc-77ed-47c3-a4d7-75d4f741d823", null, "Staff", "STAFF" },
                    { "ca26f053-0e33-4dfe-8a3a-1c0cc1ea8159", null, "Admin", "ADMIN" },
                    { "e74fd7e1-4d1f-4a4a-a9e9-8c10088173a7", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f335b97-5b9c-4980-9f70-5a19c8047406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6bb717-824b-4298-b4de-b864c114ca40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63f061dc-77ed-47c3-a4d7-75d4f741d823");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca26f053-0e33-4dfe-8a3a-1c0cc1ea8159");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74fd7e1-4d1f-4a4a-a9e9-8c10088173a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0de382ec-892b-4248-a822-5be048e3aa58", null, "Manager", "MANAGER" },
                    { "0fd290ea-4902-40b9-b0f7-64264971c60f", null, "Customer", "CUSTOMER" },
                    { "6179602b-e1ee-4863-846e-a4dd511f6a79", null, "Shipper", "SHIPPER" },
                    { "a1fe4b7f-2dc9-446c-a397-5435fde8f807", null, "Staff", "STAFF" },
                    { "a62a4b7c-c2bd-4742-90ef-eab04166455a", null, "Admin", "ADMIN" }
                });
        }
    }
}
