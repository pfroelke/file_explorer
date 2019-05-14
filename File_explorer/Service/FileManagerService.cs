using CSharp_Lab_2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab_2.Servies
{
    public class FileManagerService
    {
        public DirectoryViewModel GetRootFromUser()
        {
            var folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "Select directory to open"
            };

            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath != "")
            {
                var rootDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                var root = new DirectoryViewModel(rootDirectory.FullName);
                root.Children = getChildren(root); 
                return root;
            }
            return null;
        }

        public DirectoryViewModel SetRoot(string path)
        {
            var rootDirectory = new DirectoryInfo(path);
            var root = new DirectoryViewModel(rootDirectory.FullName);
            root.Children = getChildren(root);
            return root;
        }

        public ObservableCollection<INode> getChildren(DirectoryViewModel parent)
        {
            var result = new ObservableCollection<INode>();

            var directoryInfo = new DirectoryInfo(parent.Path);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                var newDirectory = new DirectoryViewModel(directory.FullName);

                newDirectory.Children = getChildren(newDirectory);
                result.Add(newDirectory);
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                result.Add(new FileViewModel(file.FullName));
            }

            return result;
        }
    }
}
