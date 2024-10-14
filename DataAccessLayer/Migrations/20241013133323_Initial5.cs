using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "112a4db4-9f15-437f-88a0-f2312321e440");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fc9ef2b-fc7a-4014-a31a-4b8c79578f95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8daa6c4-f274-4f74-875f-9f11649361d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4c3af35-64da-46ac-87de-63fa00268b97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d7ac6bb-1331-418d-9d0c-85cbe54b1b3b", null, "Manager", "MANAGER" },
                    { "52c7649c-810f-40a2-81b4-5dc36339c46d", null, "Shipper", "SHIPPER" },
                    { "565082d3-3a42-403e-a0e7-327970041e81", null, "Customer", "CUSTOMER" },
                    { "b8263907-2cf9-4c17-9e5e-faaada1192a1", null, "Staff", "STAFF" },
                    { "ef046331-1108-44f9-8bb5-8f756249b51d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7ac6bb-1331-418d-9d0c-85cbe54b1b3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52c7649c-810f-40a2-81b4-5dc36339c46d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "565082d3-3a42-403e-a0e7-327970041e81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8263907-2cf9-4c17-9e5e-faaada1192a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef046331-1108-44f9-8bb5-8f756249b51d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "112a4db4-9f15-437f-88a0-f2312321e440", null, "Manager", "MANAGER" },
                    { "7fc9ef2b-fc7a-4014-a31a-4b8c79578f95", null, "Customer", "CUSTOMER" },
                    { "a8daa6c4-f274-4f74-875f-9f11649361d5", null, "Admin", "ADMIN" },
                    { "c4c3af35-64da-46ac-87de-63fa00268b97", null, "Staff", "STAFF" }
                });
        }
    }
}
