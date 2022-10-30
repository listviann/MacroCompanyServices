using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCompanyServices.Migrations
{
    public partial class AddFKAttrsTiCartItem : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "ea51bdb7-68a3-4698-828c-60c2a1f53a7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89fd7d8c-036e-403b-8ebd-be999be4e6e4",
                column: "ConcurrencyStamp",
                value: "94afd675-9ae4-4bb2-8b54-e9e9f8c2273c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1c6dac7-936f-4cce-921b-d3b7d21dd8ba", "AQAAAAEAACcQAAAAEKiCldOGPhftNkzm8zQ0baYMiR7T6WW1nIup3Mb8qZeIcy0AfOLEU1OGX8VDjbWsfw==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 21, 49, 24, 636, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 21, 49, 24, 636, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 21, 49, 24, 636, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 30, 21, 49, 24, 636, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
