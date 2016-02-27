using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Models
{
    public class Cat
    {
        public string Name { get; set; }

        public void Fetch()
        {
            throw new NotImplementedException("cats don't fetch.");
        }
    }
}
