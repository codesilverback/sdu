using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
   public  class SpaceDelimitedDataRepository<T>:BaseFlatFileRepository<T>, IRepository<T> where T :class
    {
       public SpaceDelimitedDataRepository(IFileProvider fp):base(fp)
       {

       }

        public override char Delimiter
        {
            get { return ' '; }
        }

    }
}
