using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HolidayHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyToHouseNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseID",
                table: "HouseNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 22, 53, 26, 762, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 22, 53, 26, 762, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 22, 53, 26, 762, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 22, 53, 26, 762, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 22, 53, 26, 762, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.CreateIndex(
                name: "IX_HouseNumbers_HouseID",
                table: "HouseNumbers",
                column: "HouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseNumbers_Houses_HouseID",
                table: "HouseNumbers",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseNumbers_Houses_HouseID",
                table: "HouseNumbers");

            migrationBuilder.DropIndex(
                name: "IX_HouseNumbers_HouseID",
                table: "HouseNumbers");

            migrationBuilder.DropColumn(
                name: "HouseID",
                table: "HouseNumbers");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 1, 1, 37, 806, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 1, 1, 37, 806, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 1, 1, 37, 806, DateTimeKind.Local).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 1, 1, 37, 806, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 18, 1, 1, 37, 806, DateTimeKind.Local).AddTicks(9108));
        }
    }
}
