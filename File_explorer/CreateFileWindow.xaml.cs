using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharp_Lab_2
{
    /// <summary>
    /// Interaction logic for CreateFileWindow.xaml
    /// </summary>
    public partial class CreateFileWindow : Window
    {
        private string path;

        public CreateFileWindow(string path)
        {
            this.path = path;
            InitializeComponent();
        }

        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)File.IsChecked)
            {
                var fileName = FileName.Text;

                if (Regex.IsMatch(fileName, @"^[a-zA-Z.]{1,8}.(txt|php|html)")) 
                {
                    var stream = System.IO.File.Create(path + "\\" + fileName);
                    stream.Close();
                    if ((bool)ReadOnly.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + fileName, FileAttributes.ReadOnly);
                    }
                    if ((bool)Archive.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + fileName, FileAttributes.Archive);
                    }
                    if ((bool)Hidden.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + fileName, FileAttributes.Hidden);
                    }
                    if ((bool)Systemm.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + fileName, FileAttributes.System);
                    }
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Wrong file name");
                }
            }
            else if ((bool)Directory.IsChecked)
            {
                var directoryName = FileName.Text;
                if (true)
                {
                    System.IO.Directory.CreateDirectory(path + "\\" + directoryName);
                    if ((bool)ReadOnly.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + directoryName, FileAttributes.ReadOnly);
                    }
                    if ((bool)Archive.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + directoryName, FileAttributes.Archive);
                    }
                    if ((bool)Hidden.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + directoryName, FileAttributes.Hidden);
                    }
                    if ((bool)Systemm.IsChecked)
                    {
                        System.IO.File.SetAttributes(path + "\\" + directoryName, FileAttributes.System);
                    }
                    DialogResult = true;
                }
            }
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
