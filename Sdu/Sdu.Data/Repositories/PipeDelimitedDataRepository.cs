using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
   public  class PipeDelimitedDataRepository<T>:BaseFlatFileRepository<T>, IRepository<T> where T :class
    {


       public PipeDelimitedDataRepository(string filePath):base(filePath)
       {

        }

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

       public override string[] SplitLine(string line)
       {
           return line.Split('|');
       }

    }
}
