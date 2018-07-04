using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartExercise.Models;
using ShoppingCartExercise.Repositories;

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

            var model = new InventoryModel(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental", id);
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
                path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental";
            } else if(inventory_type == "user")
            {
                path = @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Users\" + user_id;
            }

            var inventory = new InventoryModel(path,inventory_id);

            if(inventory == null)
            {
                return View();
            }
            var iitem = inventory.MyInventory.Items[slot_item];
            var item = itemRepo.Load(iitem.ItemID);
            var itemModel = new ItemModel { ItemSlot = slot_item, ItemInfo = item, Price = iitem.Price, Stock = iitem.Stock, InvRef=inventory };
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


            var model = new InventoryModel(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\" + directory, id);
            model.Type = type;
            model.UserID = user_id;
            if (!model.Exists)
            {
                model = null;
            }

            return PartialView("_InventoryContainer", model);
        }

        //public ActionResult ShoppingCart(int id = 1, string type = "main", int user_id = 0)
        // {
        //}
    }
}