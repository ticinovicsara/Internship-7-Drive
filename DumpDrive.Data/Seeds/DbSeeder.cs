using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Data.Seeds
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("marko@gmail.com", "12345")
                    {
                        Id = 1,
                        DriveId = 1,
                        Name = "Marko"
                    },

                    new User("jure@gmail.com", "12345")
                    {
                        Id = 2,
                        DriveId = 2,
                        Name = "Jure"
                    },

                    new User("ana@gmail.com", "12345")
                    {
                        Id = 3,
                        DriveId = 3,
                        Name = "Ana"
                    },
                });

            builder.Entity<DDrive>()
                .HasData(new List<DDrive>
                {
                    new DDrive("Marko-drive")
                    {
                        DriveId = 1,
                        UserId = 1
                    },

                    new DDrive("Jure-drive")
                    {
                        DriveId = 2,
                        UserId = 2
                    },

                    new DDrive("Ana-drive")
                    {
                        DriveId = 3,
                        UserId = 3
                    },
                });

            builder.Entity<Folder>()
                .HasData(new List<Folder>
                {

                    new Folder("Docs")
                    {
                        ItemId = 2,
                        DriveId = 1
                    },

                    new Folder("Pictures")
                    {
                        ItemId = 3,
                        ParentFolderId = 2,
                        DriveId = 1
                    },

                    new Folder("Videos")
                    {
                        ItemId = 4,
                        DriveId = 1
                    },

                    new Folder("Oldies")
                    {
                        ItemId = 1,
                        ParentFolderId = 4,
                        DriveId = 1
                    },

                    new Folder("Projects")
                    {
                        ItemId = 5,
                        DriveId = 1
                    },

                    new Folder("Tasks")
                    {
                        ItemId = 6,
                        ParentFolderId = 2,
                        DriveId = 1
                    },

                    new Folder("Google")
                    {
                        ItemId = 7,
                        DriveId = 2
                    },

                    new Folder("Firefox")
                    {
                        ItemId = 8,
                        DriveId = 2
                    },

                    new Folder("Debian")
                    {
                        ItemId = 9,
                        DriveId = 2
                    },

                    new Folder("Git")
                    {
                        ItemId = 10,
                        ParentFolderId = 9,
                        DriveId = 2
                    },

                    new Folder("Folder")
                    {
                        ItemId = 11,
                        DriveId = 3
                    },

                    new Folder("Folder1")
                    {
                        ItemId = 12,
                        ParentFolderId = 11,
                        DriveId = 3
                    },

                    new Folder("Folder2")
                    {
                        ItemId = 13,
                        ParentFolderId = 11,
                        DriveId = 3
                    },

                    new Folder("Folder3")
                    {
                        ItemId = 14,
                        DriveId = 3
                    },
                });

            builder.Entity<Files>()
               .HasData(new List<Files>
               {
                    new Files("file1.docx", "Content file1")
                    {
                        ItemId = 15,
                        DriveId = 1,
                        ParentFolderId = 1,
                    },
                    new Files("file2.txt", "Content file2")
                    {
                        ItemId = 16,
                        DriveId = 1,
                        ParentFolderId = 2,
                    },
                    new Files("file3.pdf", "Content file3")
                    {
                        ItemId = 17,
                        DriveId = 1,
                        ParentFolderId = 3,
                    },

                    new Files("file4.docx", "Content file4")
                    {
                        ItemId = 18,
                        DriveId = 1,
                        ParentFolderId = 5,
                    },

                    new Files("file5.txt", "Content file5")
                    {
                        ItemId = 19,
                        DriveId = 1,
                    },

                    new Files("file6.docx", "Content file6")
                    {
                        ItemId = 20,
                        DriveId = 1,
                    },

                     new Files("file7.txt", "Content file7")
                    {
                        ItemId = 21,
                        DriveId = 1,
                        ParentFolderId = 2,
                    },
                    new Files("file8.pdf", "Content file8")
                    {
                        ItemId = 22,
                        DriveId = 1,
                        ParentFolderId = 6,
                    },
                    new Files("file9.txt", "Content file9")
                    {
                        ItemId = 23,
                        DriveId = 1,
                        ParentFolderId = 4,
                    },
                    new Files("file10.docx", "Content file10")
                    {
                        ItemId = 24,
                        DriveId = 1,
                        ParentFolderId = 9,
                    },
                    new Files("file11.docx", "Content file11")
                    {
                        ItemId = 25,
                        DriveId = 2,
                        ParentFolderId = 10,
                    },
                    new Files("file12.txt", "Content file12")
                    {
                        ItemId = 26,
                        DriveId = 3,
                        ParentFolderId = 11,
                    },
                    new Files("file13.pdf", "Content file13")
                    {
                        ItemId = 27,
                        DriveId = 3,
                        ParentFolderId = 12,
                    },
                    new Files("file15.docx", "Content file15")
                    {
                        ItemId = 28,
                        DriveId = 3,
                        ParentFolderId = 13,
                    },
                    new Files("file16.txt", "Content file16")
                    {
                        ItemId = 29,
                        DriveId = 3,
                        ParentFolderId = 14,
                    }
                      });



            builder.Entity<Comment>()
    .HasData(new List<Comment>
    {
                    new Comment("Comm 1")
                    {
                        CommentId = 1,
                        UserId = 1,
                        ItemId = 15,
                    },

                    new Comment("Comm 2")
                    {
                        CommentId = 2,
                        UserId = 1,
                        ItemId = 16,
                    },

                    new Comment("Comm 3")
                    {
                        CommentId = 3,
                        UserId = 1,
                        ItemId = 17,
                    },

                    new Comment("Comm 4")
                    {
                        CommentId = 4,
                        UserId = 2,
                        ItemId = 18,
                    },

                    new Comment("Comm 5")
                    {
                        CommentId = 5,
                        UserId = 3,
                        ItemId = 19,
                    },

                    new Comment("Comm 6")
                    {
                        CommentId = 6,
                        UserId = 2,
                        ItemId = 20
                    },

                    new Comment("Comm 7")
                    {
                        CommentId = 7,
                        UserId = 1,
                        ItemId = 21
                    },

                    new Comment("Comm 8")
                    {
                        CommentId = 8,
                        UserId = 3,
                        ItemId = 22
                    },

                    new Comment("Comm 9")
                    {
                        CommentId = 9,
                        UserId = 2,
                        ItemId = 23
                    },

                    new Comment("Comm 10")
                    {
                        CommentId = 10,
                        UserId = 1,
                        ItemId = 24
                    },

                    new Comment("Comm 11")
                    {
                        CommentId = 11,
                        UserId = 3,
                        ItemId = 25
                    },

                    new Comment("Comm 12")
                    {
                        CommentId = 12,
                        UserId = 2,
                        ItemId = 26
                    },

                    new Comment("Comm 13")
                    {
                        CommentId = 13,
                        UserId = 1,
                        ItemId = 27
                    },

                    new Comment("Comm 14")
                    {
                        CommentId = 14,
                        UserId = 2,
                        ItemId = 28
                    },

                    new Comment("Comm 15")
                    {
                        CommentId = 15,
                        UserId = 3,
                        ItemId = 29
                    },

                    new Comment("Comm 16")
                    {
                        CommentId = 16,
                        UserId = 1,
                        ItemId = 15
                    },

                    new Comment("Comm 17")
                    {
                        CommentId = 17,
                        UserId = 2,
                        ItemId = 16
                    },

                    new Comment("Comm 18")
                    {
                        CommentId = 18,
                        UserId = 3,
                        ItemId = 17
                    },

                    new Comment("Comm 19")
                    {
                        CommentId = 19,
                        UserId = 1,
                        ItemId = 18
                    },

                    new Comment("Comm 20")
                    {
                        CommentId = 20,
                        UserId = 2,
                        ItemId = 19
                    },

                    new Comment("Comm 21")
                    {
                        CommentId = 21,
                        UserId = 3,
                        ItemId = 20
                    },

                    new Comment("Comm 22")
                    {
                        CommentId = 22,
                        UserId = 1,
                        ItemId = 21
                    },

                    new Comment("Comm 23")
                    {
                        CommentId = 23,
                        UserId = 2,
                        ItemId = 22
                    },

                    new Comment("Comm 24")
                    {
                        CommentId = 24,
                        UserId = 3,
                        ItemId = 23
                    },

                    new Comment("Comm 25")
                    {
                        CommentId = 25,
                        UserId = 1,
                        ItemId = 24
                    },

                    new Comment("Comm 26")
                    {
                        CommentId = 26,
                        UserId = 2,
                        ItemId = 25
                    },

                    new Comment("Comm 27")
                    {
                        CommentId = 27,
                        UserId = 3,
                        ItemId = 26
                    },

                    new Comment("Comm 28")
                    {
                        CommentId = 28,
                        UserId = 1,
                        ItemId = 27
                    },

                    new Comment("Comm 29")
                    {
                        CommentId = 29,
                        UserId = 2,
                        ItemId = 28
                    },

                    new Comment("Comm 30")
                    {
                        CommentId = 30,
                        UserId = 3,
                        ItemId = 29
                    }
    });

            builder.Entity<SharedItem>()
           .HasData(new List<SharedItem>
           {
                    new SharedItem(15, 1, "file15.docx")
                    {
                        SharedItemId = 1
                    },
                    new SharedItem(16, 2, "file5.txt")
                    {
                        SharedItemId = 2
                    },
                    new SharedItem(17, 3, "file8.pdf")
                    {
                        SharedItemId = 3
                    },
                    new SharedItem(18, 1, "file10.docx")
                    {
                        SharedItemId = 4
                    },
                    new SharedItem(19, 2, "file7.txt")
                    {
                        SharedItemId = 5
                    },
                    new SharedItem(20, 3, "file11.docx")
                    {
                        SharedItemId = 6
                    },
                    new SharedItem(21, 1, "file12.txt")
                    {
                        SharedItemId = 7
                    },
                    new SharedItem(22, 2, "file13.pdf")
                    {
                        SharedItemId = 8
                    },
                    new SharedItem(23, 3, "file16.txt")
                    {
                        SharedItemId = 9
                    },
                    new SharedItem(24, 1, "file6.docx")
                    {
                        SharedItemId = 10
                    }
           });
        }
    }
}