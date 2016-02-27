using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Models
{
public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
     
        //obligatory
        //public string Quest { get; set; }  

        //database doesn't know anything about data types, so string it is!
        public string DateOfBirth { get; set; }
    }
}
