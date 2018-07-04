using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common
{
    public class User
    {
        public User()
        {
            Username = null;
            Password = null;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;           
        }

        public int ID { get; set; }
        public string Username {get; set;}
        public string Password { get; set; }
        public string Email { get; set; }
 
    }
}
