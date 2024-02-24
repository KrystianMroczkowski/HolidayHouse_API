using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HolidayHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNameColumnToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 23, 4, 22, 134, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 23, 4, 22, 134, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 23, 4, 22, 134, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 23, 4, 22, 134, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 23, 4, 22, 134, DateTimeKind.Local).AddTicks(2307));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 18, 18, 48, 956, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 18, 18, 48, 956, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 18, 18, 48, 956, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 18, 18, 48, 956, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 18, 18, 48, 956, DateTimeKind.Local).AddTicks(5424));
        }
    }
}
