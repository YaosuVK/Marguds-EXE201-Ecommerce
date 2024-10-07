using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDetails_AspNetUsers_AccountID",
                table: "VoucherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDetails_Gifts_GiftID",
                table: "VoucherDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3858ef2c-e14b-4d60-b7c0-54ede0b261ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa44a736-d730-4362-874b-3bd28769ba2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beb51427-1dbe-43d4-861b-cfce9e40010b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f77d34fa-e8ba-4ea0-9434-d4e6a1291c23");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherDetailID",
                table: "Vouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherID",
                table: "VoucherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "VoucherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GiftID",
                table: "VoucherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "VoucherDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "PlanID",
                table: "Subscriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDetails_AspNetUsers_AccountID",
                table: "VoucherDetails",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDetails_Gifts_GiftID",
                table: "VoucherDetails",
                column: "GiftID",
                principalTable: "Gifts",
                principalColumn: "GiftID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDetails_AspNetUsers_AccountID",
                table: "VoucherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherDetails_Gifts_GiftID",
                table: "VoucherDetails");

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

            migrationBuilder.AlterColumn<int>(
                name: "VoucherDetailID",
                table: "Vouchers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VoucherID",
                table: "VoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "VoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GiftID",
                table: "VoucherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "VoucherDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanID",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3858ef2c-e14b-4d60-b7c0-54ede0b261ae", null, "Manager", "MANAGER" },
                    { "aa44a736-d730-4362-874b-3bd28769ba2a", null, "Customer", "CUSTOMER" },
                    { "beb51427-1dbe-43d4-861b-cfce9e40010b", null, "Admin", "ADMIN" },
                    { "f77d34fa-e8ba-4ea0-9434-d4e6a1291c23", null, "Staff", "STAFF" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDetails_AspNetUsers_AccountID",
                table: "VoucherDetails",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherDetails_Gifts_GiftID",
                table: "VoucherDetails",
                column: "GiftID",
                principalTable: "Gifts",
                principalColumn: "GiftID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
