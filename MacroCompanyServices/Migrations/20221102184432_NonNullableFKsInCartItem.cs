using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCompanyServices.Migrations
{
    public partial class NonNullableFKsInCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "502e0354-b367-464d-812e-cc3a79366c6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89fd7d8c-036e-403b-8ebd-be999be4e6e4",
                column: "ConcurrencyStamp",
                value: "768aa517-cb9e-4eeb-9aee-ce4172993cb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad549870-ef25-4dbf-8406-48fd9966a089", "AQAAAAEAACcQAAAAEBUtwT2ESbQxIOGZIPY8Qxpv9/TkkXzgqWekTSt02EW//mwjZda0ZFN94hzCi41wyw==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 2, 23, 44, 28, 85, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 2, 23, 44, 28, 85, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 2, 23, 44, 28, 85, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 2, 23, 44, 28, 85, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "e223b132-7c6a-4d24-90bb-f35debc76886");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89fd7d8c-036e-403b-8ebd-be999be4e6e4",
                column: "ConcurrencyStamp",
                value: "560db604-07ea-43ca-ac90-3a95148bf52f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ea10cc5-3294-4739-8ab3-43bcb620c292", "AQAAAAEAACcQAAAAENuEhKpGI6Ayr3gnbQQ9PMAkeSNoNA3xDxezGV7vSRPd35QwXrIjvT4ulQ323xEvuw==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 22, 6, 20, 982, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 22, 6, 20, 982, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 22, 6, 20, 982, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 22, 6, 20, 982, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
