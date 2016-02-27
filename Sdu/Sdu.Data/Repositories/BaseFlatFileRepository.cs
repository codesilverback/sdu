using System.Collections.Generic;

namespace Sdu.Data.Repositories
{
    public  abstract class BaseFlatFileRepository<T> where T :class
    {
        protected string[] LoadFileContents(string path) {
         return    System.IO.File.ReadAllLines(path);
        }
        protected void AppendLineToFile(string path, string line) {
            System.IO.File.AppendAllLines(path, new List<string>() { line });
        }

        public abstract T ParseLine(string line);

    }
}
