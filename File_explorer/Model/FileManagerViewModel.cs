using CSharp_Lab_2.Servies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_2.Model
{
    public class FileManagerViewModel : INotifyPropertyChanged
    {
        private DirectoryViewModel root;
        public DirectoryViewModel Root
        {
            get { return root; }
            set
            {
                root = value;
                OnPropertyChanged();
            }
        }

        private INode selectedNode;
        public INode SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;
                OnPropertyChanged();
            }
        }

        private string fileContent;
        public string FileContent
        {
            get { return fileContent; }
            set
            {
                fileContent = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private FileManagerService fileManagerService;

        public FileManagerViewModel()
        {
            fileManagerService = new FileManagerService();
        }

        public void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public void SetRoot()
        {
            root = fileManagerService.GetRootFromUser();
        }

        public void SetRoot(string path)
        {
            root = fileManagerService.SetRoot(path);
        }

        async public void SetSelectedNode(string path)
        {
            var fileAttributes = File.GetAttributes(path);
            var isDirectory =
                fileAttributes.HasFlag(FileAttributes.Directory);

            if (isDirectory)
            {
                SelectedNode = new DirectoryViewModel(path);
                FileContent = "";
            }
            else
            {
                SelectedNode = new FileViewModel(path);
                var streamReader = new StreamReader(path);
                FileContent = await streamReader.ReadToEndAsync();
                streamReader.Close();
            }
        }
    }
}
