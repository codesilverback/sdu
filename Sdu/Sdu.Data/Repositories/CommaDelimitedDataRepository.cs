using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdu.Data.Models;

namespace Sdu.Data.Repositories
{
   public  class CommaDelimitedDataRepository<T>:BaseFlatFileRepository<T>, IRepository<T> where T :class
    {
       public CommaDelimitedDataRepository(IFileProvider fp):base(fp)
       {

       }
        
        public override char Delimiter {
            get { return ','; }
        }
        public override string BuildRow(T value)
        {
            ValidateAddInput(value);
            var p = value as Person;
            return String.Format("{0},{1},{2},{3},{4}", p.LastName, p.FirstName, p.Gender, p.FavoriteColor, p.DateOfBirth.ToShortDateString());
        }

    }
}
