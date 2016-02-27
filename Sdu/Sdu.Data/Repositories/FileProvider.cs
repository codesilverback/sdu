using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
    public class FileProvider : IFileProvider
    {
        string _filePath = String.Empty;
        public FileProvider(string path)
        {
            _filePath = path;
        }

        public string[] LoadFileContents()
        {
            return System.IO.File.ReadAllLines(_filePath);
        }
        public void AppendLineToFile(string line)
        {
            System.IO.File.AppendAllLines(_filePath, new List<string>() { line });
        }
    }
}
