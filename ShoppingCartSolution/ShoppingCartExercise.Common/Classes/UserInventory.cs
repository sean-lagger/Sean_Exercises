using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common.Classes
{
    public class UserInventory : Inventory
    {
        public int OwningUserID { get; set; }
    }
}
