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
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeType = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    ChangedByUserId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    Content = table.Column<string>(type: "text", nullable: true),
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
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Folders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Itemtype = table.Column<string>(type: "text", nullable: true),
                    SharedWithUserId = table.Column<int>(type: "integer", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedItem_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SharedItem_Users_SharedWithUserId",
                        column: x => x.SharedWithUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "Id", "ChangeType", "ChangedByUserId", "FileId", "Timestamp" },
                values: new object[,]
                {
                    { 10, 0, 5, 10, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 0, 6, 11, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) }
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
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "FolderId", "Name", "OwnerId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Documents", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Photos", 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Music", 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Videos", 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Projects", 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Downloads", 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Archives", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SharedItem",
                columns: new[] { "Id", "ItemId", "Itemtype", "Name", "OwnerId", "SharedWithUserId" },
                values: new object[,]
                {
                    { 1, 101, "Folder", "Document1", 1, 2 },
                    { 2, 102, "Folder", "Folder1", 2, 3 },
                    { 3, 103, "File", "Picture1", 3, 4 },
                    { 4, 104, "Folder", "VideosFolder", 4, 1 },
                    { 5, 105, "File", "Document2", 1, 3 },
                    { 6, 106, "Folder", "PhotosFolder", 2, 4 },
                    { 7, 107, "File", "VideoClip", 3, 1 },
                    { 8, 108, "Folder", "MusicFolder", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "FolderId", "LastModified", "Name", "OwnerId", "Status" },
                values: new object[,]
                {
                    { 1, "Some content for resume.pdf", 1, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "resume.pdf", 1, 0 },
                    { 2, "Image content for holiday.jpg", 2, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "holiday.jpg", 2, 0 },
                    { 3, "Audio content for song.mp3", 3, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "song.mp3", 4, 0 },
                    { 4, "Video content for movie.mp4", 4, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "movie.mp4", 3, 0 },
                    { 5, "Document content for project_plan.docx", 5, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "project_plan.docx", 2, 0 },
                    { 6, "Presentation content for presentation.pptx", 6, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "presentation.pptx", 1, 0 },
                    { 7, "Report content for report.pdf", 7, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "report.pdf", 2, 0 },
                    { 8, "Archive content for archive.zip", 4, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "archive.zip", 3, 0 },
                    { 9, "Data content for data.csv", 1, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), "data.csv", 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "AuditLogs",
                columns: new[] { "Id", "ChangeType", "ChangedByUserId", "FileId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 0, 2, 2, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, 3, 3, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 0, 4, 4, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 0, 2, 5, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 1, 3, 6, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 0, 1, 7, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 0, 3, 8, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 1, 4, 9, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "FileId", "UserId" },
                values: new object[,]
                {
                    { 1, "Great resume!", new DateTime(2025, 1, 2, 14, 8, 14, 244, DateTimeKind.Local).AddTicks(5295), 1, 1 },
                    { 2, "Lovely!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4581), 2, 2 },
                    { 3, "Nice!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4602), 9, 3 },
                    { 4, "Cool!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4607), 8, 4 },
                    { 5, "Could be better.", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4637), 7, 3 },
                    { 6, "Beautiful!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4653), 7, 2 },
                    { 7, "I dont like this song!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4657), 6, 1 },
                    { 8, "Amazing!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4660), 5, 2 },
                    { 9, "Excellent plan!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4664), 4, 3 },
                    { 10, "Great presentation!", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4668), 3, 4 },
                    { 11, "Nice.", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4672), 3, 3 },
                    { 12, "Important archive data.", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4676), 2, 2 },
                    { 13, "Data needs cleanup.", new DateTime(2025, 1, 2, 14, 8, 14, 248, DateTimeKind.Local).AddTicks(4680), 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_ChangedByUserId",
                table: "AuditLogs",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_FileId",
                table: "AuditLogs",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FileId",
                table: "Comments",
                column: "FileId");

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
                name: "IX_Folders_FolderId",
                table: "Folders",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerId",
                table: "Folders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItem_OwnerId",
                table: "SharedItem",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItem_SharedWithUserId",
                table: "SharedItem",
                column: "SharedWithUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DFileId",
                table: "Users",
                column: "DFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Files_FileId",
                table: "AuditLogs",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Users_ChangedByUserId",
                table: "AuditLogs",
                column: "ChangedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Files_FileId",
                table: "Comments",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SharedItem");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
