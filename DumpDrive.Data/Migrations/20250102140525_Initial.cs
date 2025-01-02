using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DumpDrive.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSharedFolders",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSharedFolders", x => new { x.UserId, x.FolderId });
                    table.ForeignKey(
                        name: "FK_UserSharedFolders_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSharedFolders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_AuditLogs_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Comments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSharedFiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSharedFiles", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_UserSharedFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSharedFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "ana@gmail.com", "Ana", "pass12345", "Anic" },
                    { 2, "marko@gmail.com", "Marko", "pass54322", "Markic" },
                    { 3, "josip@gmail.com", "Josip", "qwert", "Jopic" },
                    { 4, "pero@gmail.com", "Pero", "pass7", "Peric" }
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
                table: "UserSharedFiles",
                columns: new[] { "FileId", "UserId" },
                values: new object[,]
                {
                    { 10, 1 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserSharedFolders",
                columns: new[] { "FolderId", "UserId" },
                values: new object[,]
                {
                    { 10, 1 },
                    { 10, 2 },
                    { 8, 4 }
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
                table: "UserSharedFolders",
                columns: new[] { "FolderId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 6, 2 },
                    { 2, 3 },
                    { 4, 3 },
                    { 4, 4 }
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
                    { 1, "Great resume!", new DateTime(2025, 1, 2, 15, 5, 24, 895, DateTimeKind.Local).AddTicks(8923), 1, 1 },
                    { 2, "Lovely!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7333), 2, 2 },
                    { 3, "Nice!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7353), 9, 3 },
                    { 4, "Cool!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7358), 8, 4 },
                    { 5, "Could be better.", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7362), 7, 3 },
                    { 6, "Beautiful!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7376), 7, 2 },
                    { 7, "I dont like this song!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7380), 6, 1 },
                    { 8, "Amazing!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7384), 5, 2 },
                    { 9, "Excellent plan!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7387), 4, 3 },
                    { 10, "Great presentation!", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7392), 3, 4 },
                    { 11, "Nice.", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7396), 3, 3 },
                    { 12, "Important archive data.", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7399), 2, 2 },
                    { 13, "Data needs cleanup.", new DateTime(2025, 1, 2, 15, 5, 24, 898, DateTimeKind.Local).AddTicks(7403), 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserSharedFiles",
                columns: new[] { "FileId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 6, 3 },
                    { 6, 4 },
                    { 8, 4 }
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
                name: "IX_UserSharedFiles_FileId",
                table: "UserSharedFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSharedFolders_FolderId",
                table: "UserSharedFolders",
                column: "FolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserSharedFiles");

            migrationBuilder.DropTable(
                name: "UserSharedFolders");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
