using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartExercise.Common;
using Newtonsoft.Json;

namespace ShoppingCartExercise.Models
{
    public class ItemModel ///REFACTOR
    {
        public int ItemSlot { get; set; }
        public Item ItemInfo { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public InventoryModel InvRef { get; set; }
    }
}