using ShoppingCartExercise.Common;
using ShoppingCartExercise.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartExercise.Models
{



    public class InventoryModel
    {

        public InventoryModel(string path, int id)
        {
            var invRepository = new InventoryRepository();
            var itemRepository = new ItemRepository();
            var inventory = invRepository.Load(path, id);
            if (inventory == null)
            {
                Exists = false;
            }
            else
            {
                MyInventory = inventory;
                Exists = true;
                foreach (var i in inventory.Items)
                {
                    ItemList.Add(new ItemModel { ItemInfo = itemRepository.Load(i.ItemID), Price = i.Price, Stock = i.Stock, ItemSlot=i.InventorySlot, InvRef = this});
                }
            }
        }

        public int UserID { get; set; }
        public Inventory MyInventory { get; private set; }
        public string Type { get; set; }
        public bool Exists { get; set; }
        public List<ItemModel> ItemList = new List<ItemModel>();

       
    }
}