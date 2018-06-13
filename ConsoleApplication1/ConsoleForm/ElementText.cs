using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementText : Element
    {
        protected string _text;

        public ElementText() : base()
        {
            ContentText = "NULL";
            _text = ContentText;
            IsBordered = false;
        }

        public ElementText(string text) : base()
        {
            ContentText = text;
            _text = ContentText;
            IsBordered = false;
        }

        public ElementText(string text, int px, int py) : base(px, py)
        {
            ContentText = text;
            _text = ContentText;
            IsBordered = false;
        }

        public override void Display()
        {
            int Temp_X = X;
            if (IsBordered) // DON'T USE YET
            {
                ContentText = "[" + ContentText + "]";
            }else
            {
            }

            if (Centered)
            {
              //  X = 
            }

            base.Display();
            Console.Write(ContentText);
        }

        public string ContentText { get; set; } //the text content of the element (e.g the string that it displays) 
        public bool IsBordered { get; set; }
    }
}
