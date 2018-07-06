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

        }

        public void AddItem(InventoryItem item)
        {
            int index = SlotItems.Count;
            item.Slot = index;
            SlotItems.Insert(index, item);
        }

        public List<InventoryItem> SlotItems = new List<InventoryItem>();
        public int ID { get; set; }
        public string InventoryName { get; set; }
    }
}
