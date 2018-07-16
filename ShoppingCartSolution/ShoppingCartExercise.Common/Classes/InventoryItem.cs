using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ShoppingCartExercise.Common.Classes
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            Quantity = 1;
            IsInfinite = false;
        }

        public int InventoryID { get; set; }
        public int ItemInSlot { get; set; }
        public int Slot { get; set; }
        public int Quantity { get; set; }
        public bool IsInfinite { get; set; }
        public string AppendedDescription { get; set; }

    }
}