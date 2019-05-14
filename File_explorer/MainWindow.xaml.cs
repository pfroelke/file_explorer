using CSharp_Lab_2;
using CSharp_Lab_2.Model;
using CSharp_Lab_2.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp_Lab_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManagerViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            vm = new FileManagerViewModel();
            vm.SetRoot();
            DataContext = vm;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void INode_Click(object sender, RoutedEventArgs e)
        {
            var nodePath = ((TreeViewItem)sender).Tag;
            vm.SetSelectedNode(nodePath.ToString());
        }

        private void Delete_File_Click(object sender, RoutedEventArgs e)
        {
            var nodePath = ((INode)((ContextMenu)((MenuItem)sender).Parent).DataContext).Path.ToString();

            File.SetAttributes(nodePath, File.GetAttributes(nodePath) & ~FileAttributes.ReadOnly);
            File.Delete(nodePath);
            var newVm = new FileManagerViewModel();
            newVm.SetRoot(vm.Root.Path);
            vm = newVm;
            DataContext = newVm;
        }

        private void Delete_Directory_Click(object sender, RoutedEventArgs e)
        {
            var nodePath = ((INode)((ContextMenu)((MenuItem)sender).Parent).DataContext).Path.ToString();
            Directory.Delete(nodePath);
            var newVm = new FileManagerViewModel();
            newVm.SetRoot(vm.Root.Path);
            vm = newVm;
            DataContext = newVm;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var nodePath = ((INode)((ContextMenu)((MenuItem)sender).Parent).DataContext).Path.ToString();
            var dialog = new CreateFileWindow(nodePath);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                var newVm = new FileManagerViewModel();
                newVm.SetRoot(vm.Root.Path);
                vm = newVm;
                DataContext = newVm;
            }
        }
    }
}
