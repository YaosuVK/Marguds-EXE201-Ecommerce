using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Inịt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "transactionID",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_transactionID",
                table: "Subscriptions",
                column: "transactionID",
                unique: true,
                filter: "[transactionID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Transaction_transactionID",
                table: "Subscriptions",
                column: "transactionID",
                principalTable: "Transaction",
                principalColumn: "ResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Transaction_transactionID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_transactionID",
                table: "Subscriptions");

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

            migrationBuilder.DropColumn(
                name: "transactionID",
                table: "Subscriptions");

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
    }
}
