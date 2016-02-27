using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Sdu.Data.Repositories
{
    public  abstract class BaseFlatFileRepository<T> where T :class
    {
        private string _filePath = string.Empty;

        protected string[] LoadFileContents() {
         return    System.IO.File.ReadAllLines(_filePath);
        }

        protected void AppendLineToFile( string line) {
            System.IO.File.AppendAllLines(_filePath, new List<string>() { line });
        }

        public IEnumerable<T> LoadData(string[] fileContents)
        {
            var result = new List<T>();
            foreach (var s in LoadFileContents())
            {
                var t = ParseLine(s);
                if (t != null)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        public T ParseLine(string line)
        {
            var result = SplitLine(line);
            if (result[0] == "FirstName")
            {
                //header row, skip it.
                return null;
            }

            //gross, but simple:

            if (typeof(T) != typeof(Data.Models.Person))
            {
                throw new NotImplementedException(String.Format("No implementation for repo of type {0}", typeof(T).Name));
            }


            //this is gross and bizarre and I don't like it.  But I really want to use IRepo<T>
            return new Models.Person()
            {
                FirstName = result[0],
                LastName = result[1],
                Gender = result[2],
                DateOfBirth = result[3]
            } as T;
        }

        public abstract string[] SplitLine(string line);
    }
}
