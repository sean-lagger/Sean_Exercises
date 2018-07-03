using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartExercise.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace ShoppingCartExercise.Repositories
{
    public class UserRepository
    {
        JavaScriptSerializer _jss = new JavaScriptSerializer();

        public bool Save(User user)
        {

            try{
                
                string data = _jss.Serialize(user);
                string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Users\" + user.ID; //CHANGE LATER
                // string path = HttpContext.Current.Server.MapPath("~") + @"\Data\Users\" + user.Username;
                if (Directory.Exists(path))
                {
                    System.IO.File.WriteAllText(path + @"\user_info.json", data);
                }
                else
                {
                    Directory.CreateDirectory(path);
                    System.IO.File.WriteAllText(path + @"\user_info.json", data);
                }
       
                return true;
            }
            catch(Exception e)
            {
                return false;
            }          
        }

        public User Load(int id)
        {
            string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Users\" + id;
            if (Directory.Exists(path))
            {
                try
                {
                    User toReturn = new User();
                    using (StreamReader r = new StreamReader(path + @"\user_info.json"))
                    {
                        toReturn = _jss.Deserialize<User>(r.ReadToEnd());

                    }
                    return toReturn;
                }
                catch(Exception e)
                {
                    return null;
                }
            }else
            {
                return null;
            }
        }

    }
}
