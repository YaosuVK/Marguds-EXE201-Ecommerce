using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "163a832b-bae8-4ea9-ae3f-056c024fb562", null, "Customer", "CUSTOMER" },
                    { "2cbc2940-d099-47d4-b733-4087ab3a3540", null, "Shipper", "SHIPPER" },
                    { "d87543ad-9c68-4f46-84d4-f4771a52001a", null, "Manager", "MANAGER" },
                    { "fa5831f6-8a18-4c29-b8c4-da5624d1979c", null, "Staff", "STAFF" },
                    { "fe786a6b-faf7-4916-875d-bc2b85426967", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "163a832b-bae8-4ea9-ae3f-056c024fb562");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cbc2940-d099-47d4-b733-4087ab3a3540");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d87543ad-9c68-4f46-84d4-f4771a52001a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa5831f6-8a18-4c29-b8c4-da5624d1979c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe786a6b-faf7-4916-875d-bc2b85426967");

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
    }
}
