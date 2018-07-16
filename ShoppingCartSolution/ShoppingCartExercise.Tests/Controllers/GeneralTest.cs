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
using ShoppingCartExercise.Common.Classes;
using System.Diagnostics;

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

        //[TestMethod]
        //public void UserSaveTest()
        //{
        //    User user = new User { ID = 1, Username = "Test2", Password = "Password" };
        //    UserRepository repo = new UserRepository();


        //    Assert.IsTrue(repo.Save(user));

        //}

        //[TestMethod]
        //public void UserLoadTest()
        //{
        //    var user = new User();
        //    var repo = new UserRepository();

        //    user = repo.Load(1);

        //    Assert.IsNotNull(user);

        //}

        //[TestMethod]
        //public void ItemSaveTest()
        //{
        //    var item = new Item { ID = 1, Name = "TestItem", Description = "Our Latest Product!", ImagePath = "item_1.jpg" };
        //    var item2 = new Item { ID = 2, Name = "TestItem2", Description = "Our Latest Product!2", ImagePath = "item_2.png" };
        //    var item3 = new Item { ID = 3, Name = "TestItem3", Description = "Our Latest Product!3", ImagePath = "item_1.jpg" };
        //    var repo = new ItemRepository();

        //    repo.Save(item2);
        //    repo.Save(item3);

        //    Assert.IsTrue(repo.Save(item));

        //}

        //[TestMethod]
        //public void ItemLoadTest()
        //{
        //    User user = new User();
        //    UserRepository repo = new UserRepository();

        //    user = repo.Load(1);

        //    Assert.IsNotNull(user);

        //}

        //[TestMethod]
        //public void InventorySaveTest()
        //{
        //    var inventory = new Inventory { InventoryName = "Experimental Inventory", ID = 1 };

        //    inventory.AddItem(new InventoryItem { ItemID = 1, Price = 100, Stock = 1 });
        //    inventory.AddItem(new InventoryItem { ItemID = 2, Price = 200, Stock = 4 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });
        //    inventory.AddItem(new InventoryItem { ItemID = 3, Price = 300, Stock = 6 });


        //    var repo = new InventoryRepository();

        //    Assert.IsTrue(repo.Save(inventory,  @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental"));

        //}

        //[TestMethod]
        //public void InventoryLoadTest()
        //{
        //   Inventory inv = new Inventory();
        //   InventoryRepository repo = new InventoryRepository();

        //    inv = repo.Load(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\Data\Experimental\", 1);

        //    Assert.IsNotNull(inv);

        //}

        [TestMethod]
        public void ItemSaveTest()
        {

            var itemList = new List<Item>();

            itemList.Add(new Item { ID = itemList.Count+1, DefaultDescription = "Our Latest Product", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count+1), Category = "Category1"});
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Our Latest Product2", ImageSource = "item_2.png", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category1" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Our Latest Product3", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category1" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Our Latest Product4", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category1" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Our Latest Product5", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category1" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Limited Time Offer", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category2" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Limited Time Offer2", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category2" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Limited Time Offer3", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category2" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Limited Time Offer4", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category2" });
            itemList.Add(new Item { ID = itemList.Count + 1, DefaultDescription = "Limited Time Offer5", ImageSource = "item_1.jpg", ItemName = "TestItem_" + (itemList.Count + 1), Category = "Category2" });
            ItemRepository itemRepo = new ItemRepository();

            foreach (var i in itemList)
            {
                itemRepo.Save(i, @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Items\"+i.ID+".json");
            }

            Assert.IsTrue(true);

        }

        [TestMethod]
        public void ItemLoadTest()
        {
            Item item1 = new Item { ID = 1, DefaultDescription = "Our Latest Product", ImageSource = "image_1.jpg", ItemName = "TestItem"  };
            ItemRepository itemRepo = new ItemRepository();

            var item2 = itemRepo.Load(1, @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Items\");

            Assert.AreEqual(item1.ID, item2.ID);
        }

        [TestMethod]
        public void InventorySaveTest()
        {
            MarketInventory inventory = new MarketInventory { ID = 1, InventoryName = "Test Inventory" };
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "For Sale!", IsInfinite = false, ItemInSlot = 1, Quantity = 10, Price = 100});
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "Limited Offer Only!!!", IsInfinite = false, ItemInSlot = 2, Quantity = 2, Price = 200 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "For Sale!", IsInfinite = false, ItemInSlot = 3, Quantity = 10, Price = 100 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "Limited Offer Only!!!", IsInfinite = false, ItemInSlot = 4, Quantity = 2, Price = 300 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "For Sale!", IsInfinite = false, ItemInSlot = 5, Quantity = 10, Price = 100 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "Limited Offer Only!!!", IsInfinite = false, ItemInSlot = 6, Quantity = 2, Price = 150 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "For Sale!", IsInfinite = false, ItemInSlot = 7, Quantity = 10, Price = 100 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "Limited Offer Only!!!", IsInfinite = false, ItemInSlot = 8, Quantity = 2, Price = 150 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "For Sale!", IsInfinite = false, ItemInSlot = 9, Quantity = 10, Price = 100 });
            inventory.AddItem(new MarketInventoryItem { AppendedDescription = "Limited Offer Only!!!", IsInfinite = false, ItemInSlot = 10, Quantity = 2, Price = 650 });

            InventoryRepository invRepo = new InventoryRepository();

            Assert.IsTrue(invRepo.Save(inventory, @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\"));
        }

        [TestMethod]
        public void InventoryLoadTest()
        {
            InventoryRepository invRepo = new InventoryRepository();
            MarketInventory inventory = (invRepo.Load(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Market\inventory_1.json") as MarketInventory);

            Console.WriteLine(inventory.InventoryName);
            Assert.IsNotNull(inventory);
        }
        [TestMethod]
        public void PlusPlus()
        {
            int a = 5;
            Assert.IsTrue(a++ == 5);
        }



            //[TestMethod]
            //public void InventoryLoadItemsTest1()
            //{
            //    Stopwatch sw1 = new Stopwatch();
            //    Stopwatch sw2 = new Stopwatch();

            //    //Empty string is much faster than null;

            //    //Test 1
            //    InventoryRepository<MarketInventory> invRepo = new InventoryRepository<MarketInventory>();
            //    ItemRepository itemRepo = new ItemRepository();
            //    var inventory = invRepo.Load(@"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Market\inventory_1.json");

            //    var listReturn = new List<Item>();
            //    string[] category = { null, "", "Category1", "Category2" };


            //    Console.WriteLine("--Test 1--");
            //    sw2.Restart();
            //    foreach (var j in category)
            //    {
            //        Console.WriteLine("Test 1 with Category: {0} ", j);
            //        sw1.Restart();
            //        foreach (var i in inventory.SlotItems)
            //        {
            //            Item k = itemRepo.Load(i.ItemInSlot, @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Items\");

            //            if (j != String.Empty && j != null)
            //            {
            //                if (k.Category == j)
            //                {
            //                    listReturn.Add(k);
            //                    Console.WriteLine("Added {0} of category: {1} to Return List at : {2}", k.ItemName, j, sw1.ElapsedTicks);
            //                }
            //            }
            //            else
            //            {
            //                listReturn.Add(k);
            //                Console.WriteLine("Added {0} of null category to Return List at : {1}", k.ItemName, sw1.ElapsedTicks);
            //            }

            //        }
            //        sw1.Stop();
            //        Console.WriteLine("Elapsed = {0}", sw1.ElapsedTicks);
            //    }

            //    sw2.Stop();
            //    Console.WriteLine("Test 1 Total Elapsed  Time= {0}", sw2.ElapsedTicks);

            //    Console.WriteLine("--Test 2--");
            //    sw2.Restart();
            //    List<Item> loadItems = new List<Item>();

            //    foreach(var l in inventory.SlotItems)
            //    {
            //        loadItems.Add(itemRepo.Load(l.ItemInSlot, @"E:\Projects\Sean_Exercises\ShoppingCartSolution\ShoppingCartExercise\App_Data\Items\"));
            //    }

            //    foreach (var j in category)
            //    {
            //        Console.WriteLine("Test 2 with Category: {0} ", j);
            //        sw1.Restart();
            //        foreach (var i in loadItems)
            //        {
            //            if (j != String.Empty && j != null)
            //            {
            //                if (i.Category == j)
            //                {
            //                    listReturn.Add(i);
            //                    Console.WriteLine("Added {0} of category: {1} to Return List at : {2}", i.ItemName, j, sw1.ElapsedTicks);
            //                }
            //            }
            //            else
            //            {
            //                listReturn.Add(i);
            //                Console.WriteLine("Added {0} of null category to Return List at : {1}", i.ItemName, sw1.ElapsedTicks);
            //            }

            //        }
            //        sw1.Stop();
            //        Console.WriteLine("Elapsed = {0}", sw1.ElapsedTicks);
            //    }
            //    sw2.Stop();
            //    Console.WriteLine("Test 2 Total Elapsed  Time= {0}", sw2.ElapsedTicks);

            //    Assert.IsTrue(true);
            //}
        }
}
