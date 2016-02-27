using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Repositories
{
   public static class ExtensionMethods
    {
       public static string CleanedUp(this string value)
       {
           return value.Replace("\"", "");

       }

    }
}
