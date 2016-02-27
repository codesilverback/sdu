using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sdu.WebApi.Models
{
    public class Record
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}