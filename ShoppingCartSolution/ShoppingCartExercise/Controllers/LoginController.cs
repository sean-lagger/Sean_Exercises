using ShoppingCartExercise.Common;
using ShoppingCartExercise.Models;
using ShoppingCartExercise.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartExercise.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            UserRepository repo = new UserRepository();

            if (ModelState.IsValid)
            {
                User user = new User();
                user = repo.Load(userModel.UserData.ID);
                if(user != null)
                {
                    if(user.Password == userModel.UserData.Password)
                    {
                        Session["Username"] = user.Username;
                        return RedirectToAction("Index", "Home");
                    }else
                    {
                        return View(userModel);
                    }
                    
                    
                }else
                {
                    return View(userModel);
                }

            }

            return View(userModel);
        }
    }
}