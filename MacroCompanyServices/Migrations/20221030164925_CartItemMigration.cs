using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCompanyServices.Migrations
{
    public partial class CartItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "a354ba65-730f-4926-8275-492daa42289d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89fd7d8c-036e-403b-8ebd-be999be4e6e4",
                column: "ConcurrencyStamp",
                value: "8c0a3001-2b8f-4e3f-accc-3f34475e2eef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9cc64b6f-4279-41a9-b427-98570797a545", "AQAAAAEAACcQAAAAEGCmUXou4aQlpaYei6/MRy/E7Hpn9b+opWp0LFSustvAGNnm2vG3KbgN4D+4vtXW5Q==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 23, 48, 28, 957, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 23, 48, 28, 957, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 23, 48, 28, 957, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 23, 48, 28, 957, DateTimeKind.Local).AddTicks(4983));
        }
    }
}
