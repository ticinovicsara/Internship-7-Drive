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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DFileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    DFileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Files_DFileId",
                        column: x => x.DFileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Folders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Itemtype = table.Column<string>(type: "text", nullable: false),
                    SharedWithUserId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_SharedWithUserId",
                        column: x => x.SharedWithUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DFileId", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, null, "ana@gmail.com", "Ana", "pass12345", "Anic" },
                    { 2, null, "marko@gmail.com", "Marko", "pass54322", "Markic" },
                    { 3, null, "josip@gmail.com", "Josip", "qwert", "Jopic" },
                    { 4, null, "pero@gmail.com", "Pero", "pass7", "Peric" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "DFileId", "FileId", "UserId" },
                values: new object[,]
                {
                    { 1, "Great resume!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(654), null, 1, 1 },
                    { 2, "Lovely!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(679), null, 2, 2 },
                    { 3, "Nice!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(685), null, 3, 4 },
                    { 4, "Cool!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(690), null, 4, 1 },
                    { 5, "Could be better.", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(695), null, 1, 1 },
                    { 6, "Beautiful!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(703), null, 2, 3 },
                    { 7, "I dont like this song!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(708), null, 3, 3 },
                    { 8, "Amazing!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(713), null, 4, 4 },
                    { 9, "Excellent plan!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(719), null, 5, 2 },
                    { 10, "Great presentation!", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(725), null, 6, 1 },
                    { 11, "Nice.", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(730), null, 7, 1 },
                    { 12, "Important archive data.", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(736), null, 8, 2 },
                    { 13, "Data needs cleanup.", new DateTime(2025, 1, 1, 19, 36, 27, 322, DateTimeKind.Local).AddTicks(741), null, 9, 3 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "Name", "OwnerId", "ParentFolderId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Documents", 1, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Photos", 2, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music", 3, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Videos", 4, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Projects", 1, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Downloads", 2, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Archives", 3, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "FolderId", "LastModified", "Name", "OwnerId", "Status" },
                values: new object[,]
                {
                    { 1, "Some content for resume.pdf", 1, new DateTime(2025, 1, 1, 19, 36, 27, 318, DateTimeKind.Local).AddTicks(7681), "resume.pdf", 0, 0 },
                    { 2, "Image content for holiday.jpg", 2, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7360), "holiday.jpg", 0, 1 },
                    { 3, "Audio content for song.mp3", 3, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7393), "song.mp3", 0, 0 },
                    { 4, "Video content for movie.mp4", 4, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7399), "movie.mp4", 0, 1 },
                    { 5, "Document content for project_plan.docx", 5, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7403), "project_plan.docx", 0, 0 },
                    { 6, "Presentation content for presentation.pptx", 5, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7418), "presentation.pptx", 0, 1 },
                    { 7, "Report content for report.pdf", 6, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7421), "report.pdf", 0, 0 },
                    { 8, "Archive content for archive.zip", 7, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7425), "archive.zip", 0, 1 },
                    { 9, "Data content for data.csv", 7, new DateTime(2025, 1, 1, 19, 36, 27, 321, DateTimeKind.Local).AddTicks(7428), "data.csv", 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DFileId",
                table: "Comments",
                column: "DFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerId",
                table: "Folders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_OwnerId",
                table: "SharedItems",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_SharedWithUserId",
                table: "SharedItems",
                column: "SharedWithUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DFileId",
                table: "Users",
                column: "DFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Files_DFileId",
                table: "Comments",
                column: "DFileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_OwnerId",
                table: "Files",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_DFileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SharedItems");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
