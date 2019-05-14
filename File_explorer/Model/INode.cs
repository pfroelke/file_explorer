using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_2.Model
{
    public interface INode
    {
        string Name { get; set; }
        string Path { get; set; }
        string Info { get; }
        bool IsDirectory { get; set; }
    }
}
