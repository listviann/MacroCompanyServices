using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCompanyServices.Migrations
{
    public partial class OrdinaryUserRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "a354ba65-730f-4926-8275-492daa42289d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89fd7d8c-036e-403b-8ebd-be999be4e6e4", "8c0a3001-2b8f-4e3f-accc-3f34475e2eef", "ordinary_user", "ORDINARY_USER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89fd7d8c-036e-403b-8ebd-be999be4e6e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                column: "ConcurrencyStamp",
                value: "57040b2b-16fd-4e94-a662-70bb93cea689");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07187c28-8a32-4ff0-a88d-3245e5197eae", "AQAAAAEAACcQAAAAEEGuvknvVBaTcPwgkslijtdVk1NcBuAmhTBzf06+N8+doL1uJx4ApG5Y4P8zh+9nGg==" });

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 23, 9, 37, 48, 130, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 23, 9, 37, 48, 130, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 23, 9, 37, 48, 130, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "PagesData",
                keyColumn: "Id",
                keyValue: new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                column: "DateAdded",
                value: new DateTime(2022, 10, 23, 9, 37, 48, 130, DateTimeKind.Local).AddTicks(6914));
        }
    }
}
