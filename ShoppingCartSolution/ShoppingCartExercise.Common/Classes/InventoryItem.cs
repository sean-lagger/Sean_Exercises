using ShoppingCartExercise.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common
{
    public class InventoryItem : IPriceable
    {

        public InventoryItem()
        {
            ItemID = 0;
            Stock = 0;
            Price = 0;
        }

        public InventoryItem(int itemID)
        {
            ItemID = itemID;
        }

        public InventoryItem(int itemID, int price)
        {
            ItemID = itemID;
            Price = price;
        }

        public InventoryItem(int itemID, int price, int stock)
        {
            ItemID = itemID;
            Price = price;
            Stock = stock;
        }

        public int ItemID { get; set; }
        public int Price{ get; set; }
        public int Stock { get; set; }
    }
}
