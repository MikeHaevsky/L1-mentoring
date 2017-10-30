using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FileProvider : IFileProvider
    {
        public string[] GetDir(string dir)
        {
            return Directory.GetDirectories(dir);
        }

        public string[] GetFiles(string dir)
        {
            return Directory.GetFiles(dir);
        }
    }
}
