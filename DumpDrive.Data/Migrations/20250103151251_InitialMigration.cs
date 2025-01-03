using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DumpDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DriveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriveId);
                    table.ForeignKey(
                        name: "FK_Drives_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DriveId = table.Column<int>(type: "integer", nullable: false),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: true),
                    ParentFolderItemId = table.Column<int>(type: "integer", nullable: true),
                    Item_type = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "DriveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Items_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Items_ParentFolderItemId",
                        column: x => x.ParentFolderItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedItems",
                columns: table => new
                {
                    SharedItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedItems", x => x.SharedItemId);
                    table.ForeignKey(
                        name: "FK_SharedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedItems_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "DriveId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 15, 12, 50, 305, DateTimeKind.Utc).AddTicks(734), 1, "marko@gmail.com", "Marko", "12345" },
                    { 2, new DateTime(2025, 1, 3, 15, 12, 50, 305, DateTimeKind.Utc).AddTicks(2077), 2, "jure@gmail.com", "Jure", "12345" },
                    { 3, new DateTime(2025, 1, 3, 15, 12, 50, 305, DateTimeKind.Utc).AddTicks(2082), 3, "ana@gmail.com", "Ana", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriveId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Marko-drive", 1 },
                    { 2, "Jure-drive", 2 },
                    { 3, "Ana-drive", 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(2688), 1, "Folder", null, "Docs", null, null },
                    { 4, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3685), 1, "Folder", null, "Videos", null, null },
                    { 5, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3688), 1, "Folder", null, "Projects", null, null },
                    { 7, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3708), 2, "Folder", null, "Google", null, null },
                    { 8, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3709), 2, "Folder", null, "Firefox", null, null },
                    { 9, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3711), 2, "Folder", null, "Debian", null, null },
                    { 11, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3715), 3, "Folder", null, "Folder", null, null },
                    { 14, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3720), 3, "Folder", null, "Folder3", null, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 19, "Content file5", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5088), 1, "File", null, "file5.txt", null, null },
                    { 20, "Content file6", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5092), 1, "File", null, "file6.docx", null, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 5, "Comm 5", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6978), 19, 3 },
                    { 6, "Comm 6", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6982), 20, 2 },
                    { 20, "Comm 20", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7002), 19, 2 },
                    { 21, "Comm 21", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7004), 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3686), 1, "Folder", null, "Oldies", 4, null },
                    { 3, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3445), 1, "Folder", null, "Pictures", 2, null },
                    { 6, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3706), 1, "Folder", null, "Tasks", 2, null },
                    { 10, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3713), 2, "Folder", null, "Git", 9, null },
                    { 12, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3716), 3, "Folder", null, "Folder1", 11, null },
                    { 13, new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(3718), 3, "Folder", null, "Folder2", 11, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 16, "Content file2", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5041), 1, "File", null, "file2.txt", 2, null },
                    { 18, "Content file4", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5087), 1, "File", null, "file4.docx", 5, null },
                    { 21, "Content file7", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5093), 1, "File", null, "file7.txt", 2, null },
                    { 23, "Content file9", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5096), 1, "File", null, "file9.txt", 4, null },
                    { 24, "Content file10", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5099), 1, "File", null, "file10.docx", 9, null },
                    { 26, "Content file12", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5103), 3, "File", null, "file12.txt", 11, null },
                    { 29, "Content file16", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5108), 3, "File", null, "file16.txt", 14, null }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 5, 19, "file7.txt", 2 },
                    { 6, 20, "file11.docx", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 2, "Comm 2", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6973), 16, 1 },
                    { 4, "Comm 4", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6977), 18, 2 },
                    { 7, "Comm 7", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6983), 21, 1 },
                    { 9, "Comm 9", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6986), 23, 2 },
                    { 10, "Comm 10", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6988), 24, 1 },
                    { 12, "Comm 12", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6991), 26, 2 },
                    { 15, "Comm 15", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6995), 29, 3 },
                    { 17, "Comm 17", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6997), 16, 2 },
                    { 19, "Comm 19", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7001), 18, 1 },
                    { 22, "Comm 22", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7005), 21, 1 },
                    { 24, "Comm 24", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7008), 23, 3 },
                    { 25, "Comm 25", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7009), 24, 1 },
                    { 27, "Comm 27", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7012), 26, 3 },
                    { 30, "Comm 30", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7016), 29, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 15, "Content file1", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(4755), 1, "File", null, "file1.docx", 1, null },
                    { 17, "Content file3", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5044), 1, "File", null, "file3.pdf", 3, null },
                    { 22, "Content file8", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5095), 1, "File", null, "file8.pdf", 6, null },
                    { 25, "Content file11", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5101), 2, "File", null, "file11.docx", 10, null },
                    { 27, "Content file13", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5104), 3, "File", null, "file13.pdf", 12, null },
                    { 28, "Content file15", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(5106), 3, "File", null, "file15.docx", 13, null }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 2, 16, "file5.txt", 2 },
                    { 4, 18, "file10.docx", 1 },
                    { 7, 21, "file12.txt", 1 },
                    { 9, 23, "file16.txt", 3 },
                    { 10, 24, "file6.docx", 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 1, "Comm 1", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6006), 15, 1 },
                    { 3, "Comm 3", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6975), 17, 1 },
                    { 8, "Comm 8", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6984), 22, 3 },
                    { 11, "Comm 11", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6989), 25, 3 },
                    { 13, "Comm 13", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6992), 27, 1 },
                    { 14, "Comm 14", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6993), 28, 2 },
                    { 16, "Comm 16", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(6996), 15, 1 },
                    { 18, "Comm 18", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7000), 17, 3 },
                    { 23, "Comm 23", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7007), 22, 2 },
                    { 26, "Comm 26", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7011), 25, 2 },
                    { 28, "Comm 28", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7013), 27, 1 },
                    { 29, "Comm 29", new DateTime(2025, 1, 3, 15, 12, 50, 306, DateTimeKind.Utc).AddTicks(7014), 28, 2 }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 1, 15, "file15.docx", 1 },
                    { 3, 17, "file8.pdf", 3 },
                    { 8, 22, "file13.pdf", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_UserId",
                table: "Drives",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_DriveId",
                table: "Items",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParentFolderId",
                table: "Items",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParentFolderItemId",
                table: "Items",
                column: "ParentFolderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_ItemId",
                table: "SharedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_UserId",
                table: "SharedItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SharedItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
