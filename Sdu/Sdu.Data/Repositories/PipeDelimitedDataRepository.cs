using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
   public  class PipeDelimitedDataRepository<T>:BaseFlatFileRepository<T>, IRepository<T> where T :class
    {
       public PipeDelimitedDataRepository(IFileProvider fp):base(fp)
       {

       }

        public override char Delimiter
        {
            get { return '|'; }
        }

    }
}
