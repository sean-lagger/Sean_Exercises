using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartExercise.Models;
using ShoppingCartExercise.Repositories;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ShoppingCartExercise.Controllers
{
    public class ExperimentController : Controller
    {
        // GET: Experiment
        public ActionResult Index()
        {
            //Test
            return View();
        }

        [HttpGet]
        public ActionResult ItemViewer(int id = 1)
        {

            var model = new InventoryModel(Server.MapPath(@"~\Data\Experimental\"), id);
            model.Type = "main";
            if (Request.IsAjaxRequest())
            {
                return PartialView("_InventoryContainer", model);
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult ItemPage(string inventory_type = "", int inventory_id = 0, int slot_item = 0, int user_id = 0)
        {
            //TODO
            var itemRepo = new ItemRepository();
            var invRepo = new InventoryRepository();
            string path = "";
            if (inventory_type == "main")
            {
                path = Server.MapPath(@"~\Data\Experimental\");
            } else if(inventory_type == "user")
            {
                path = Server.MapPath(@"~\Data\Users\") + user_id;
            }

            var inventory = new InventoryModel(path,inventory_id);

            if(inventory == null)
            {
                return View();
            }
            var inventoryitem = inventory.MyInventory.Items[slot_item];
            var item = itemRepo.Load(inventoryitem.ItemID);
            var itemModel = new ItemModel { ItemSlot = slot_item, ItemInfo = item, Price = inventoryitem.Price, Stock = inventoryitem.Stock, InvRef=inventory };
            if(itemModel.Equals(null))
            {
                return View();
            }
                return View(itemModel);
        }

        public PartialViewResult GetInventory(int id = 1, string type = "main", int user_id = 0)
        {
            string directory = "";
            if (type == "main")
            {
                directory = "Experimental";
            }
            else if (type == "user")
            {
                directory = @"Users\" + user_id;
            }


            var model = new InventoryModel(Server.MapPath(@"~\Data\") + directory, id);
            model.Type = type;
            model.UserID = user_id;
            if (!model.Exists)
            {
                model = null;
            }

            return PartialView("_InventoryContainer", model);
        }

        public EmptyResult AddToCart(string inventory_type = "", int inventory_id = 0, int slot_item = 0, int user_id = 0)
        {
            var itemRepo = new ItemRepository();
            var invRepo = new InventoryRepository();
            string path = "";
            if (inventory_type == "main")
            {
                path = Server.MapPath(@"~\Data\Experimental\");
            }
            else if (inventory_type == "user")
            {
                path = Server.MapPath(@"~\Data\Users\") + user_id;
            }

            var inventory = new InventoryModel(path, inventory_id);
            inventory.Type = inventory_type;


            var list = JsonConvert.DeserializeObject<List<ShoppingCartModel>>((string)Session["ShoppingCart"]);
            var scModel = new ShoppingCartModel { Type = inventory_type, SlotItem = slot_item, InventoryID = inventory_id, UserID = user_id };
            if (!list.Exists(x => x.Equals(scModel)))
            {
                list.Add(scModel);
            }
            Session["ShoppingCart"] = JsonConvert.SerializeObject(list);
            return new EmptyResult();
        }

        private ItemModel GetItemModel(ShoppingCartModel model)
        {
            string directory = "";
            if (model.Type == "main")
            {
                directory = "Experimental";
            }
            else if (model.Type == "user")
            {
                directory = @"Users\" + model.UserID;
            }

            var itemRepo = new ItemRepository();
            var inventory = new InventoryModel(Server.MapPath(@"~\Data\") + directory, model.InventoryID);
            inventory.Type = model.Type;
            inventory.UserID = model.UserID;
            var inventoryItem = inventory.MyInventory.Items[model.SlotItem];
            return new ItemModel { InvRef=inventory, ItemInfo=itemRepo.Load(inventoryItem.ItemID),ItemSlot= model.SlotItem,Price=inventoryItem.Price,Stock=inventoryItem.Stock };
        }

        public ActionResult ShoppingCartPage()
        { 
            
            var list = JsonConvert.DeserializeObject<List<ShoppingCartModel>>((string)Session["ShoppingCart"]); 

            var toReturnList = new List<ItemModel>();

            foreach(var i in list)
            {
                toReturnList.Add(GetItemModel(i));
            }

            return View(toReturnList);
        }

        //public ActionResult ShoppingCart(int id = 1, string type = "main", int user_id = 0)
        // {
        //}
    }
}