using ShoppingCartExercise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Web;
using Newtonsoft.Json;
using ShoppingCartExercise.Common.Classes;

namespace ShoppingCartExercise.Repositories
{
    public class InventoryRepository : BaseRepository<Inventory>
    {
        public bool Save(Inventory inventory)
        {
             string path = HttpContext.Current.Server.MapPath(@"~\App_Data\");
             return(Save(inventory, path));

        }

        public bool Save(Inventory inventory, string path)
        {

            try
            {
                if (inventory is MarketInventory)
                {
                    path += @"Market\";
                }
                else if (inventory is UserInventory)
                {
                    path += @"Users\" + (inventory as UserInventory).OwningUserID + @"\";
                }

                return (FileWrite(path + "inventory_" + inventory.ID + ".json", JsonConvert.SerializeObject(inventory,settings)));

            }
            catch
            {
                return false;
            }
        }

        public Inventory Load(string path)
        {
            try
            {
                return (FileLoad(path));
            }
            catch
            {
                return null;
            }
        }

        public Inventory Load(int inventory_id)
        {       
            return (Load(HttpContext.Current.Server.MapPath(@"~\App_Data\Market\inventory_" + inventory_id + ".json")));
        }

        public Inventory Load(int inventory_id, int user_id)
        {
            return(Load(HttpContext.Current.Server.MapPath(@"~\App_Data\Users\" + user_id + @"\inventory_"+inventory_id+".json")));
        }
    }


}
