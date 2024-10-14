using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "Vouchers",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_AccountID",
                table: "Vouchers",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_AspNetUsers_AccountID",
                table: "Vouchers",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_AspNetUsers_AccountID",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_AccountID",
                table: "Vouchers");

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

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Vouchers");

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
    }
}
