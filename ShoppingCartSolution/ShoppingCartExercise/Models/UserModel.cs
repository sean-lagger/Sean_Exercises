using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartExercise.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartExercise.Models
{
    public class UserModel : ValidationAttribute
    {
        public UserModel()
        {
            UserData = new User();
        }


        public UserModel(User user)
        {
            UserData = user;
        }

        [Required]
        [StringLength(32)]
        [MinLength(8)]
        public string Username {
            get
            {
                return UserData.Username;
            }
            set
            {
                UserData.Username = value;
            }
        }

        [Required]
        [StringLength(32)]
        [MinLength(8)]
        public string Password
        {
            get
            {
                return UserData.Password;
            }
            set
            {
                UserData.Password = value;
            }
        }

        public User UserData { get; set; }
    }
}