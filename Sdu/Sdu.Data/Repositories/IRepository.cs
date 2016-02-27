using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
    interface IRepository<T> where T :class
    {
        IQueryable<T> AsQueryable();
        void Insert(T value); 
    }
}
