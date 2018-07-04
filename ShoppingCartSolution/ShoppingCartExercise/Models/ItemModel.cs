using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartExercise.Common;

namespace ShoppingCartExercise.Models
{
    public struct ItemModel
    {
        public int ItemSlot;
        public Item ItemInfo;
        public int Stock;
        public int Price;
        public InventoryModel InvRef;
    }
}