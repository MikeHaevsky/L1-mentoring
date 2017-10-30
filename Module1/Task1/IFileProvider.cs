using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IFileProvider
    {
        string[] GetFiles(string dir);

        string[] GetDir(string dir);
    }
}
