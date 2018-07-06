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
using Newtonsoft.Json;
using ShoppingCartExercise.Common.Classes;

namespace ShoppingCartExercise.Repositories
{
    public class ItemRepository : BaseRepository<Item>
    {
        
        public bool Save(Item item)
        {
            try
            {
                return(FileWrite(HttpContext.Current.Server.MapPath(@"~\App_Data\Items\")+item.ID+".json", JsonConvert.SerializeObject(item)));
            }
            catch
            {
                return false;
            }
        }

        public bool Save(Item item, string path)
        {
            try
            {
                return(FileWrite(path, JsonConvert.SerializeObject(item)));
            }
            catch
            {
                return false;
            }
        }

        public Item Load(int inventory_id)
        {
            try
            {
                return (FileLoad(HttpContext.Current.Server.MapPath(@"~\App_Data\Items\") + inventory_id + ".json"));
            }catch
            {
                return null;
            }
        }

        public Item Load(int inventory_id, string path)
        {
            try
            {
                return (FileLoad(path + inventory_id + ".json"));
            }
            catch
            {
                return null;
            }
        }

    }
}
