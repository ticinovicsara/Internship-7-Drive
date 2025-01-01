using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 83, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 79, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 46, 57, 82, DateTimeKind.Local).AddTicks(7438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 318, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastModified",
                value: new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7428));
        }
    }
}
