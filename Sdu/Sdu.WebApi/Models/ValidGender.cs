using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace Sdu.WebApi.Models
{
    public class ValidGender:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
           
            if (value.ToString() == "male" || value.ToString() == "female")
            {
                return true;
            }

            return false;
        }
    }
}