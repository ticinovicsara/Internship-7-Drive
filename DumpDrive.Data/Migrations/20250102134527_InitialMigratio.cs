using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Itemtype",
                table: "SharedItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 645, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 45, 26, 648, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Itemtype",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Itemtype",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Itemtype",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Itemtype",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Itemtype",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Itemtype",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Itemtype",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Itemtype",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Itemtype",
                table: "SharedItem",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 244, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Itemtype",
                value: "Folder");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Itemtype",
                value: "Folder");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Itemtype",
                value: "File");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Itemtype",
                value: "Folder");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Itemtype",
                value: "File");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Itemtype",
                value: "Folder");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Itemtype",
                value: "File");

            migrationBuilder.UpdateData(
                table: "SharedItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Itemtype",
                value: "Folder");
        }
    }
}
