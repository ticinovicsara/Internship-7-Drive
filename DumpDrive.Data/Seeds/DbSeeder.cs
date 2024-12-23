using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Seeds
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var anaId = 1;
            var markoId = 2;
            var josipId = 3;
            var peroId = 4;

            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("ana@gmail.com", "pass12345", "Ana", "Anic") { Id = anaId }
                    new User("marko@gmail.com", "pass54322", "Marko", "Markic") { Id = markoId },
                    new User("josip@gmail.com", "qwert", "Josip", "Jopic") { Id = josipId },
                    new User("pero@gmail.com", "pass7", "Pero", "Peric") { Id = peroId }
                });

            var folder1Id = 1;
            var folder2Id = 2;
            var folder3Id = 3;
            var folder4Id = 4;
            var folder5Id = 5;
            var folder6Id = 6;
            var folder7Id = 7;

            builder.Entity<Folder>()
                .HasData(new List<Folder>
                {
                    new Folder("Documents", anaId) { Id = folder1Id, Status = Status.Private },
                    new Folder("Photos", markoId) { Id = folder2Id, Status = Status.Shared },
                    new Folder("Music", josipId) { Id = folder3Id, Status = Status.Private },
                    new Folder("Videos", peroId) { Id = folder4Id, Status = Status.Shared },
                    new Folder("Projects", anaId) { Id = folder5Id, Status = Status.Private },
                    new Folder("Downloads", markoId) { Id = folder6Id, Status = Status.Shared },
                    new Folder("Archives", josipId) { Id = folder7Id, Status = Status.Private }
                });

            var file1Id = 1;
            var file2Id = 2;
            var file3Id = 3;
            var file4Id = 4;
            var file5Id = 5;
            var file6Id = 6;
            var file7Id = 7;
            var file8Id = 8;
            var file9Id = 9;

            builder.Entity<<File>
                .HasData(new List<File>
                {
                    new File("resume.pdf", folder1Id, Status.Private) { Id = file1Id },
                    new File("holiday.jpg", folder2Id, Status.Shared) { Id = file2Id },
                    new File("song.mp3", folder3Id, Status.Private) { Id = file3Id },
                    new File("movie.mp4", folder4Id, Status.Shared) { Id = file4Id },
                    new File("project_plan.docx", folder5Id, Status.Private) { Id = file5Id },
                    new File("presentation.pptx", folder5Id, Status.Shared) { Id = file6Id },
                    new File("report.pdf", folder6Id, Status.Private) { Id = file7Id },
                    new File("archive.zip", folder7Id, Status.Shared) { Id = file8Id },
                    new File("data.csv", folder7Id, Status.Private) { Id = file9Id }
                });

            builder.Entity<Comment>()
                .HasData(new List<Comment>
                {
                new Comment("Great resume!", file1Id, ivonaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Lovely picture!", file2Id, jureId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Nice music!", file3Id, brunoId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Cool video!", file4Id, anaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("This resume could be better.", file1Id, anaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Beautiful image!", file2Id, brunoId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("I dont like this song!", file3Id, brunoId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Amazing video!", file4Id, jureId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Excellent project plan!", file5Id, jureId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Great presentation!", file6Id, anaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Very detailed report!", file7Id, ivonaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Important archive data.", file8Id, jureId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment("Data needs cleanup.", file9Id, ivonaId) { Id = Guid.NewGuid(), CreatedAt = DateTime.Now }
                });

            builder.Entity<AuditLog>()
                .HasData(new List<AuditLog>
                {
                new AuditLog(ChangeType.Created, file1Id, ivonaId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Created, file2Id, jureId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Updated, file3Id, brunoId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Created, file4Id, anaId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Created, file5Id, jureId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Updated, file6Id, brunoId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Created, file7Id, ivonaId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Created, file8Id, brunoId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now },
                new AuditLog(ChangeType.Updated, file9Id, anaId) { Id = Guid.NewGuid(), Timestamp = DateTime.Now }
                });
        }
    }
}
