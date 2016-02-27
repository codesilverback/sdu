using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Sdu.Data.Repositories
{
    public abstract class BaseFlatFileRepository<T> :IRepository<T> where T : class
    {
        private IFileProvider _fileProvider = null;
         
         
        public BaseFlatFileRepository(IFileProvider fp)
        {
            _fileProvider = fp;
        }

        public IQueryable<T> AsQueryable()
        {
            return LoadData().AsQueryable();
        }


        protected IEnumerable<T> LoadData()
        {
            var result = new List<T>();
            foreach (var s in _fileProvider.LoadFileContents())
            {
                var t = ParseLine(s);
                if (t != null)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        public void Insert(T value)
        {
            throw new NotImplementedException();
        }



        protected T ParseLine(string line)
        {
            var result = SplitLine(line);
            if (result[0].Replace("\"","") == "LastName")
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
                FirstName = result[0].Replace("\"", ""),
                LastName = result[1].Replace("\"", ""),
                Gender = result[2].Replace("\"", ""),
                DateOfBirth = result[3].Replace("\"", "")
            } as T;
        }

        public abstract string[] SplitLine(string line);
    }
}
