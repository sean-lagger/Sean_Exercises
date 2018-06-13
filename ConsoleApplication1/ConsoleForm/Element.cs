using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class Element
    {
        private static int highest_id = 0;

        public Element()
        {
            ID = highest_id++;
            ElementType = "element";
            X = 0;
            Y = 0;
            Length = 1;
        }

        public Element(string type): this()
        {
            ElementType = type;
        }

        public Element(int px, int py) : this()
        {
            X = px;
            Y = py;
        }


        public Element(string type, int px, int py): this(type)
        {
            X = px;
            Y = py;
      }



        public virtual void Display()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
        }

        public int ID { get; set; }
        public int X { get; set; } 
        public int Y { get; set; }
        public CForm ParentForm { get; set; }
        public bool Centered { get; set; }
        public int Length { get; set; } //offset of two if borders are enabled
        public string ElementType { get; protected set; }
        
        
    }
}
