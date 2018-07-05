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

        public List<InventoryItem> SlotItems = new List<InventoryItem>();
        public int ID { get; set; }
        public string InventoryName { get; set; }
        public string Path { get; set; }
    }
}
