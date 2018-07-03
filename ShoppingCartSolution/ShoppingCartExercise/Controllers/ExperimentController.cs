using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartExercise.Models;

namespace ShoppingCartExercise.Controllers
{
    public class ExperimentController : Controller
    {
        // GET: Experiment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ItemViewer(int id = 1)
        {

            var model = new InventoryModel(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental", id);
            if(Request.IsAjaxRequest())
            {
                return PartialView("_InventoryContainer", model);
            }else
            {
                return View(model);
            }
           
        }

        [ChildActionOnly]
        public PartialViewResult InventoryUpdate(int id = 1)
        {

            var model = new InventoryModel(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental", id);

            return PartialView("_InventoryContainer", model);
        }
    }
}