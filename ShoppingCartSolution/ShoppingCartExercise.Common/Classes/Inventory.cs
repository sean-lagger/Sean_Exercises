using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common.Classes
{

    public class Inventory
    {
        public Inventory()
        {
            SlotItems = new List<InventoryItem>();
        }

        public void AddItem(InventoryItem item)
        {
            int index = SlotItems.Count;
            item.Slot = index;
            item.InventoryID = ID;
            SlotItems.Insert(index, item);
        }

        public bool Decrement(int slot, int n)
        {
            var item = SlotItems[slot];
            if(item.Quantity > n)
            {
                item.Quantity -= n;
                if (item.Quantity <= 0)
                {
                    SlotItems.RemoveAt(slot);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<InventoryItem> SlotItems { get; set; }
        public int ID { get; set; }
        public string InventoryName { get; set; }
    }
}
