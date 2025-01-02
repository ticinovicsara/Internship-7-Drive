namespace DumpDrive.Data.Entities.Models
{
    public class CurrentFolder
    {

        public Folder? Folder { get; set; }

        public CurrentFolder(Folder? initialFolder = null)
        {
            Folder = initialFolder;
        }

    }
}
