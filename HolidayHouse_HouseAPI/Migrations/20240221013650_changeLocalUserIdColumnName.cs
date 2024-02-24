using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HolidayHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeLocalUserIdColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "LocalUsers",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 2, 36, 50, 333, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 2, 36, 50, 333, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 2, 36, 50, 333, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 2, 36, 50, 333, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 2, 36, 50, 333, DateTimeKind.Local).AddTicks(7652));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LocalUsers",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 22, 39, 38, 766, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 22, 39, 38, 766, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 22, 39, 38, 766, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 22, 39, 38, 766, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 22, 39, 38, 766, DateTimeKind.Local).AddTicks(6062));
        }
    }
}
