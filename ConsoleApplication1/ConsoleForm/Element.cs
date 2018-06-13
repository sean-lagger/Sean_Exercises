using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public abstract class Element
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

        public Element(string type)
        {
            ElementType = type;
        }

        public Element(string type, int px, int py)
        {
            ElementType = type;
            X = px;
            Y = py;
        }

        public virtual void Display()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            if (IsBordered)
            {
                ContentText = "["+ ContentText + "]";
            }
            Console.Write(ContentText);  //run base.Display() 
        }

        public int ID {

            get
            {
                return ID;
            }

            private set
            {

            }
        }
        public int X { get; set; } 
        public int Y { get; set; }
        public int Width { get; set; }
        public int Length { get; set; } //offset of two if borders are enabled
        public bool IsBordered { get; set; }
        public string ElementType { get; private set; }
        public string ContentText { get; set; } //the text content of the element (e.g the string that it displays) 
        
    }
}
