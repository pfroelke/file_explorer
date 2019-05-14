using CSharp_Lab_2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CSharp_Lab_2.Converter
{
    class ContextMenuConverter : IValueConverter
    {
        public ContextMenu DirectoryMenu { get; set; }
        public ContextMenu FileMenu { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                if (type == typeof(FileViewModel))
                    return FileMenu;
                else if (type == typeof(DirectoryViewModel))
                    return DirectoryMenu;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
