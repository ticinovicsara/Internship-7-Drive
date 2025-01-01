using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Seeds
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("ana@gmail.com", "pass12345", "Ana", "Anic") { Id = 1 },
                    new User("marko@gmail.com", "pass54322", "Marko", "Markic") { Id = 2 },
                    new User("josip@gmail.com", "qwert", "Josip", "Jopic") { Id = 3 },
                    new User("pero@gmail.com", "pass7", "Pero", "Peric") { Id = 4 }
                });

            builder.Entity<Folder>()
                .HasData(new List<Folder>
                {
                    new Folder("Documents", 1) { Id = 1, Status = Status.Private },
                    new Folder("Photos", 2) { Id = 2, Status = Status.Shared },
                    new Folder("Music", 3) { Id = 3, Status = Status.Private },
                    new Folder("Videos", 4) { Id = 4, Status = Status.Shared },
                    new Folder("Projects", 3) { Id = 5, Status = Status.Private },
                    new Folder("Downloads", 2) { Id = 6, Status = Status.Shared },
                    new Folder("Archives", 1) { Id = 7, Status = Status.Private }
                });

            builder.Entity<DFile>()
                .HasData(new List<DFile>
                {
                    new DFile("resume.pdf", 1, Status.Private) { Id = 1, Content = "Some content for resume.pdf" },
                    new DFile("holiday.jpg", 2, Status.Shared) { Id = 2, Content = "Image content for holiday.jpg" },
                    new DFile("song.mp3", 3, Status.Private) { Id = 3, Content = "Audio content for song.mp3" },
                    new DFile("movie.mp4", 4, Status.Shared) { Id = 4, Content = "Video content for movie.mp4" },
                    new DFile("project_plan.docx", 5, Status.Private) { Id = 5, Content = "Document content for project_plan.docx" },
                    new DFile("presentation.pptx", 6, Status.Shared) { Id = 6, Content = "Presentation content for presentation.pptx" },
                    new DFile("report.pdf", 7, Status.Private) { Id = 7, Content = "Report content for report.pdf" },
                    new DFile("archive.zip", 4, Status.Shared) { Id = 8, Content = "Archive content for archive.zip" },
                    new DFile("data.csv", 1, Status.Private) { Id = 9, Content = "Data content for data.csv" }
                });


            builder.Entity<Comment>()
                .HasData(new List<Comment>
                {
                    new Comment("Great resume!", 1, 1) { Id = 1, CreatedAt = DateTime.Now },
                    new Comment("Lovely!", 2, 2) { Id = 2, CreatedAt = DateTime.Now },
                    new Comment("Nice!", 9, 3) { Id = 3, CreatedAt = DateTime.Now },
                    new Comment("Cool!", 8, 4) { Id = 4, CreatedAt = DateTime.Now },
                    new Comment("Could be better.", 7, 3) { Id = 5, CreatedAt = DateTime.Now },
                    new Comment("Beautiful!", 7, 2) { Id = 6, CreatedAt = DateTime.Now },
                    new Comment("I dont like this song!", 6, 1) { Id = 7, CreatedAt = DateTime.Now },
                    new Comment("Amazing!", 5, 2) { Id = 8, CreatedAt = DateTime.Now },
                    new Comment("Excellent plan!", 4, 3) { Id = 9, CreatedAt = DateTime.Now },
                    new Comment("Great presentation!", 3, 4) { Id = 10, CreatedAt = DateTime.Now },
                    new Comment("Nice.", 3, 3) { Id = 11, CreatedAt = DateTime.Now },
                    new Comment("Important archive data.", 2, 2) { Id = 12, CreatedAt = DateTime.Now },
                    new Comment("Data needs cleanup.", 6, 1) { Id = 13, CreatedAt = DateTime.Now }
                });
            
        }
    }
}
