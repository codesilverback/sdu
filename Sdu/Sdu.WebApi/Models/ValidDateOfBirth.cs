using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace Sdu.WebApi.Models
{
    public class ValidDateOfBirth : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime parseDateTime;
            if (!DateTime.TryParse(value.ToString(), out parseDateTime))
            {
                return false;
            }

            if (parseDateTime < DateTime.UtcNow.AddYears(-120))
            {
                //too old
                return false;
            }


            if (parseDateTime > DateTime.UtcNow)
            {
                //too young
                return false;
            }

            return true;
        }
    }
}