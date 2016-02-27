using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
   public  class PipeDelimitedDataRepository<T>:BaseFlatFileRepository<T>, IRepository<T> where T :class
    {
 
        public IQueryable<T> AsQueryable() {
            throw new NotImplementedException();
        }

        public void Add() {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public override T ParseLine(string line)
        {
            var result = line.Split('|');
            if (result[0] == "FirstName")
            {
                //header row, skip it.
                return null;
            }

            //gross, but simple:

            if (typeof(T) !=  typeof(Data.Models.Person)){
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
    }
}
