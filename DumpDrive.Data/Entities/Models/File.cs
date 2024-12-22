using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int OwnerId { get; set; }
        public int FolderId { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public User Owner { get; set; }
        public Folder Folder { get; set; }
    }

}
