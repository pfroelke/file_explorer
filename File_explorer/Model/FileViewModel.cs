using System.IO;

namespace CSharp_Lab_2.Model
{
    public class FileViewModel : INode
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public string Info
        {
            get
            {
                return (this.Name + ": " + this.GetDosAttributes());
            }
        }

        public FileViewModel(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            Name = directoryInfo.Name;
            Path = directoryInfo.FullName;
            IsDirectory = false;
        }
    }
}
