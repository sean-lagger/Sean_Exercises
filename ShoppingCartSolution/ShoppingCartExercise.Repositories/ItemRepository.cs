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
    public class ItemRepository
    {
        JavaScriptSerializer _jss = new JavaScriptSerializer();

        public bool Save(Item item)
        {

            try{    
                string data = _jss.Serialize(item);
                string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Items\"; //CHANGE LATER
                // string path = HttpContext.Current.Server.MapPath("~") + @"\Data\Users\" + user.Username;
                if (Directory.Exists(path))
                {
                    System.IO.File.WriteAllText(path + @"\" + item.ID + ".json", data);
                }
                else
                {
                    Directory.CreateDirectory(path);
                    System.IO.File.WriteAllText(path + @"\" + item.ID + ".json", data);
                }
       
                return true;
            }
            catch(Exception e)
            {
                return false;
            }          
        }

        public Item Load(int id)
        {
            string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Items\";
            if (Directory.Exists(path))
            {
                try
                {
                    Item toReturn = new Item();
                    using (StreamReader r = new StreamReader(path + @"\"+ id +".json"))
                    {
                        toReturn = _jss.Deserialize<Item>(r.ReadToEnd());
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
