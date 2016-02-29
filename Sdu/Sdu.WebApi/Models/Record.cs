using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sdu.WebApi.Models
{
    public class Record
    {
        private string _gender = string.Empty;
        private string _favoriteColor = string.Empty;

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [ValidGender]
        public string Gender
        {
            get
            {
                return _gender;
            }

            set { _gender = value.ToLowerInvariant(); }
        }
        [Required()]
        [MaxLength(255)]
        public string FavoriteColor {
            get
            {
                return _favoriteColor;
            }

            set { _favoriteColor = value.ToLowerInvariant(); }
        }


        [ValidDateOfBirth]
        public DateTime DateOfBirth { get; set; }
    }

}