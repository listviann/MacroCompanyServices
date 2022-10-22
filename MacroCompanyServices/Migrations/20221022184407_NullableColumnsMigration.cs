using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCompanyServices.Migrations
{
    public partial class NullableColumnsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "a1f5349f-ade0-467c-9cdd-ad6131383dba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d28ca496-1f99-47d7-8566-4e92a4d8b502", "AQAAAAEAACcQAAAAEJNdO6kO0N2Gwg2Rx/w5X+8YO1USjvpg+rcAeDo45N3cAMDHQZZiqTB6ZAJksxsKIw==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 22, 23, 44, 6, 922, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 22, 23, 44, 6, 922, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 22, 23, 44, 6, 922, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 22, 23, 44, 6, 922, DateTimeKind.Local).AddTicks(9599));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "d62da9a3-9c66-49ba-86d1-46148a50a3e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b439d35f-1f40-4e1d-8054-11d5636b5f27", "AQAAAAEAACcQAAAAEMyXWknzX4oyAB8HvHwmEMFsKT556V3ETeOb6pxVeMchRkKNq1q4pR3qXCnoIrg1rA==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 21, 48, 47, 178, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 21, 48, 47, 178, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 21, 48, 47, 178, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 21, 48, 47, 178, DateTimeKind.Local).AddTicks(1859));
        }
    }
}
