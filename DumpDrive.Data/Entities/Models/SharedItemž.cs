using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class SharedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Itemtype { get; set; }
        public int SharedWithUserId { get; set; }

        public User SharedWithUser { get; set; }
        public User Owner { get; set; }
    }
}
