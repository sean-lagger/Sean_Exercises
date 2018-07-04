using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartExercise;
using ShoppingCartExercise.Controllers;
using ShoppingCartExercise.Common;
using ShoppingCartExercise.Repositories;

namespace ShoppingCartExercise.Tests.Controllers
{
    [TestClass]
    public class GeneralTest
    {
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void UserSaveTest()
        {
            User user = new User { ID = 1, Username = "Test2", Password = "Password" };
            UserRepository repo = new UserRepository();


            Assert.IsTrue(repo.Save(user));

        }

        [TestMethod]
        public void UserLoadTest()
        {
            var user = new User();
            var repo = new UserRepository();

            user = repo.Load(1);

            Assert.IsNotNull(user);

        }

        [TestMethod]
        public void ItemSaveTest()
        {
            var item = new Item { ID = 1, Name = "TestItem", Description = "Our Latest Product!", ImagePath = "item_1.jpg" };
            var item2 = new Item { ID = 2, Name = "TestItem2", Description = "Our Latest Product!2", ImagePath = "item_2.png" };
            var item3 = new Item { ID = 3, Name = "TestItem3", Description = "Our Latest Product!3", ImagePath = "item_1.jpg" };
            var repo = new ItemRepository();

            repo.Save(item2);
            repo.Save(item3);

            Assert.IsTrue(repo.Save(item));

        }

        [TestMethod]
        public void ItemLoadTest()
        {
            User user = new User();
            UserRepository repo = new UserRepository();

            user = repo.Load(1);

            Assert.IsNotNull(user);

        }

        [TestMethod]
        public void InventorySaveTest()
        {
            var inventory = new Inventory { InventoryName = "Experimental Inventory", ID = 1 };

            inventory.AddItem(new InventoryItem { ItemID = 1, Price = 100, Stock = 1 });
            inventory.AddItem(new InventoryItem { ItemID = 2, Price = 200, Stock = 4 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
            inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });


            var repo = new InventoryRepository();

            Assert.IsTrue(repo.Save(inventory,  @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental"));

        }

        [TestMethod]
        public void InventoryLoadTest()
        {
           Inventory inv = new Inventory();
           InventoryRepository repo = new InventoryRepository();

            inv = repo.Load(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental\", 1);

            Assert.IsNotNull(inv);

        }


    }
}
