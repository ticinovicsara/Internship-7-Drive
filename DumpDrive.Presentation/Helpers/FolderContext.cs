using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Presentation.Helpers
{
    public class FolderContext
    {
        public Folder? Folder { get; set; }

        public FolderContext(Folder? initialFolder = null)
        {
            Folder = initialFolder;
        }
    }
}
