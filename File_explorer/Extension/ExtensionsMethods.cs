using CSharp_Lab_2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_2
{
    public static class ExtensionsMethods
    {
        public static string GetDosAttributes(this INode node)
        {
            var item = new DirectoryInfo(node.Path);
            string result = item.Attributes.HasFlag(FileAttributes.ReadOnly) ? "r" : "-";
            result += item.Attributes.HasFlag(FileAttributes.Archive) ? "a" : "-";
            result += item.Attributes.HasFlag(FileAttributes.Hidden) ? "h" : "-";
            result += item.Attributes.HasFlag(FileAttributes.System) ? "s" : "-";
            return result;
        }
    }
}
