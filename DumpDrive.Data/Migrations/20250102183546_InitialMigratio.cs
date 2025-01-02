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
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Users_UserId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedItems_Users_UserId",
                table: "SharedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 126, DateTimeKind.Utc).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(941));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(948));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 127, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 125, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 125, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 35, 46, 125, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_users_UserId",
                table: "Drives",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedItems_users_UserId",
                table: "SharedItems",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_users_UserId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_SharedItems_users_UserId",
                table: "SharedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Users_UserId",
                table: "Drives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedItems_Users_UserId",
                table: "SharedItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
