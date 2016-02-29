using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sdu.Data.Models;

namespace Sdu.Data.Repositories
{
    public abstract class BaseFlatFileRepository<T> :IRepository<T> where T : class
    {
        private IFileProvider _fileProvider = null;
         
        
        public abstract char Delimiter { get; }
         
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
            _fileProvider.AppendLineToFile(this.BuildRow(value));
        }

        public abstract string BuildRow(T value);

        protected void ValidateAddInput(T value)
        {
            //again, totally repulsive, but I really want to use T and not make the repo for a particular type.

            if (typeof(T) != typeof(Person))
            {
                throw new NotImplementedException(String.Format("This repo only works for People, you provided {0}.",
                    typeof(T).Name));
            }
        }

        protected T ParseLine(string line)
        {
            if (line == String.Empty)
            {
                return null;
            }
            var result = line.Split(this.Delimiter);

            if (result[0].CleanedUp() == "LastName")
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
                LastName = result[0].CleanedUp(),
                FirstName= result[1].CleanedUp(),
                Gender = result[2].CleanedUp().ToLowerInvariant(),
                FavoriteColor = result[3].CleanedUp().ToLowerInvariant(),
                DateOfBirth = DateTime.Parse( result[4].CleanedUp()),
            } as T;
        }


        
        
    }
}
