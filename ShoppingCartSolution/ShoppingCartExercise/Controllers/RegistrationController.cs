using ShoppingCartExercise.Common;
using ShoppingCartExercise.Models;
using ShoppingCartExercise.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExercise.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                UserRepository repo = new UserRepository();
                if (repo.Save(userModel.UserData))
                {
                    return RedirectToAction("Index", "Home");
                }else
                {
                    return Content("Error Saving File");
                }
                
            }
            return View(userModel);
        }
    }
}