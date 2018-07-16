using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common.Classes
{

    public class MarketInventoryItem : InventoryItem
    {
        public MarketInventoryItem() : base()
        {

        }

        public decimal Price { get; set; }
        
    }
}
