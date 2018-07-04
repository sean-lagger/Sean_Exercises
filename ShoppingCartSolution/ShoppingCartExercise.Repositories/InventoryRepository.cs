using ShoppingCartExercise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace ShoppingCartExercise.Repositories
{
    public class InventoryRepository
    {
        JavaScriptSerializer _jss = new JavaScriptSerializer();

        private string pathToUser(int id)
        {
            string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Users\" + id;
            return path;
        }

        public Inventory Load(string path, int id)
        {

            if (Directory.Exists(path))
            {
                try
                {
                    var toReturn = new Inventory();
                    var itemRepo = new ItemRepository();

                    using (StreamReader r = new StreamReader(path + @"\inventory_" + id + ".json"))
                    {
                        toReturn = _jss.Deserialize<Inventory>(r.ReadToEnd());
                    }

                    return toReturn;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Inventory Load(int uid, int id)
        {
            
            return Load(pathToUser(uid), id);
        }

        public bool Save(Inventory t, string path)
        {
            try
            {

                //string path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\" + @"\Data\Users\" + user.ID; //CHANGE LATER
                // string path = HttpContext.Current.Server.MapPath("~") + @"\Data\Users\" + user.Username;
                string data = _jss.Serialize(t);

                if (Directory.Exists(path))
                {
                    System.IO.File.WriteAllText(path + @"\inventory_" + t.ID + @".json", data);
                }
                else
                {
                    Directory.CreateDirectory(path);
                    System.IO.File.WriteAllText(path + @"\inventory_" + t.ID + @".json", data);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(Inventory t, int uid)
        {
            return (Save(t, pathToUser(uid)));
        }
    }
}
