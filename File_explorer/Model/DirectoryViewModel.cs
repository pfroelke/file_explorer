using System.Collections.ObjectModel;
using System.IO;

namespace CSharp_Lab_2.Model
{
    public class DirectoryViewModel : INode
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public string Info
        {
            get {
                return (this.Name + ": " + this.GetDosAttributes());
            }
        }

        public ObservableCollection<INode> Children { get; set; }

        public DirectoryViewModel(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            Name = directoryInfo.Name;
            Path = directoryInfo.FullName;
            IsDirectory = true;
        }
    }
}
