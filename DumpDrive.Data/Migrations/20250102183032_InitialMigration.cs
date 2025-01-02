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
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                        name: "FK_Drives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_SharedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DriveId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(2345), 1, "luka@gmail.com", "Luka", "12345" },
                    { 2, new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(5560), 2, "ante@gmail.com", "Anto", "12345" },
                    { 3, new DateTime(2025, 1, 2, 18, 30, 31, 488, DateTimeKind.Utc).AddTicks(5565), 3, "mate@gmail.com", "Ana", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriveId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Lukin-disk", 1 },
                    { 2, "Antin-disk", 2 },
                    { 3, "Matin-disk", 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(2520), 1, "Folder", null, "Fesb-predavanja", null, null },
                    { 4, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4166), 1, "Folder", null, "Slike", null, null },
                    { 5, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4171), 1, "Folder", null, "Dokumenti", null, null },
                    { 7, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4197), 2, "Folder", null, "Recepti", null, null },
                    { 8, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4200), 2, "Folder", null, "Svasta", null, null },
                    { 9, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4203), 2, "Folder", null, "Projekti", null, null },
                    { 11, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4209), 3, "Folder", null, "Operacijski-sustavi", null, null },
                    { 14, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4216), 3, "Folder", null, "Folder-za-faks", null, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 19, "Review", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6729), 1, "File", null, "Review.txt", null, null },
                    { 20, "Content for Recepti", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6735), 1, "File", null, "Recepti.docx", null, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 5, "Komentar 5", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(43), 19, 3 },
                    { 6, "Komentar 6", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(53), 20, 2 },
                    { 20, "Komentar 20", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(82), 19, 2 },
                    { 21, "Komentar 21", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(83), 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4168), 1, "Folder", null, "Moje slike", 4, null },
                    { 3, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(3711), 1, "Folder", null, "Web-prog", 2, null },
                    { 6, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4194), 1, "Folder", null, "Projektni-zadaci", 2, null },
                    { 10, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4206), 2, "Folder", null, "Zavrsni-rad", 9, null },
                    { 12, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4211), 3, "Folder", null, "Linux", 11, null },
                    { 13, new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(4213), 3, "Folder", null, "Windows", 11, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 16, "Content for Fesb Predavanja Slides", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6721), 1, "File", null, "predavanje.txt", 2, null },
                    { 18, "Content for Personal Documents", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6727), 1, "File", null, "osobni-dokument.docx", 5, null },
                    { 21, "Class notes", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6737), 1, "File", null, "notes.txt", 2, null },
                    { 23, "A random picture", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6742), 1, "File", null, "picture-description.txt", 4, null },
                    { 24, "List of tasks", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6745), 1, "File", null, "tasklist.docx", 9, null },
                    { 26, "Notes on OS", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6750), 3, "File", null, "system-notes.txt", 11, null },
                    { 29, "Plan for studying", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6932), 3, "File", null, "study-plan.txt", 14, null }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 5, 19, "Review.txt", 2 },
                    { 6, 20, "Recepti.docx", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 2, "Komentar 2", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(36), 16, 1 },
                    { 4, "Komentar 4", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(41), 18, 2 },
                    { 7, "Komentar 7", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(54), 21, 1 },
                    { 9, "Komentar 9", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(58), 23, 2 },
                    { 10, "Komentar 10", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(62), 24, 1 },
                    { 12, "Komentar 12", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(66), 26, 2 },
                    { 15, "Komentar 15", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(71), 29, 3 },
                    { 17, "Komentar 17", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(75), 16, 2 },
                    { 19, "Komentar 19", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(80), 18, 1 },
                    { 22, "Komentar 22", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(86), 21, 1 },
                    { 24, "Komentar 24", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(89), 23, 3 },
                    { 25, "Komentar 25", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(91), 24, 1 },
                    { 27, "Komentar 27", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(94), 26, 3 },
                    { 30, "Komentar 30", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(100), 29, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Content", "CreatedAt", "DriveId", "Item_type", "LastChangedAt", "Name", "ParentFolderId", "ParentFolderItemId" },
                values: new object[,]
                {
                    { 15, "Content for Dump Domaci Notes", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6190), 1, "File", null, "domaci.docx", 1, null },
                    { 17, "Content for Web Programiranje Code", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6725), 1, "File", null, "preza.pdf", 3, null },
                    { 22, "Project summary", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6739), 1, "File", null, "summary.pdf", 6, null },
                    { 25, "Thesis draft", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6748), 2, "File", null, "thesis.docx", 10, null },
                    { 27, "Linux guide", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6752), 3, "File", null, "linux-guide.pdf", 12, null },
                    { 28, "Windows FAQ", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(6754), 3, "File", null, "windows-faq.docx", 13, null }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 2, 16, "predavanje.txt", 2 },
                    { 4, 18, "osobni-dokument.docx", 1 },
                    { 7, 21, "notes.txt", 1 },
                    { 9, 23, "picture.jpg", 3 },
                    { 10, 24, "tasklist.docx", 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ItemId", "UserId" },
                values: new object[,]
                {
                    { 1, "Komentar 1", new DateTime(2025, 1, 2, 18, 30, 31, 490, DateTimeKind.Utc).AddTicks(8594), 15, 1 },
                    { 3, "Komentar 3", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(39), 17, 1 },
                    { 8, "Komentar 8", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(57), 22, 3 },
                    { 11, "Komentar 11", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(64), 25, 3 },
                    { 13, "Komentar 13", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(67), 27, 1 },
                    { 14, "Komentar 14", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(69), 28, 2 },
                    { 16, "Komentar 16", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(73), 15, 1 },
                    { 18, "Komentar 18", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(78), 17, 3 },
                    { 23, "Komentar 23", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(88), 22, 2 },
                    { 26, "Komentar 26", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(93), 25, 2 },
                    { 28, "Komentar 28", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(96), 27, 1 },
                    { 29, "Komentar 29", new DateTime(2025, 1, 2, 18, 30, 31, 491, DateTimeKind.Utc).AddTicks(98), 28, 2 }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "SharedItemId", "ItemId", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 1, 15, "domaci.docx", 1 },
                    { 3, 17, "preza.pdf", 3 },
                    { 8, 22, "summary.pdf", 2 }
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
                name: "Users");
        }
    }
}
