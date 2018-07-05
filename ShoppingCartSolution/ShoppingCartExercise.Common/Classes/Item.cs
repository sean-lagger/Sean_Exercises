using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartExercise.Common.Classes
{
    public class Item
    {
        public Item()
        {

        }

        public int ID { get; set; }
        public string ItemName {get; set;}
        public string DefaultDescription { get; set; }
        public string ImageSource { get; set; }
    }
}
