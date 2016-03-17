using PhoenixSample.PCL;
using PhoenixSystem.Monogame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixSample.Windows
{
    public class FileReader : IFileReader
    {
        public string[] GetFileContents(string Path)
        {
            return File.ReadAllLines(Path);
        }
    }
}
