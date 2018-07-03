﻿using ShoppingCartExercise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common
{
    public class Inventory
    {
        public Inventory()
        {

        }

        public int ID { get; set; }
        public string InventoryName { get; set; }
        public List<InventoryItem> Items = new List<InventoryItem>();
    }
}