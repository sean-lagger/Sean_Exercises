using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementText : Element
    {
        protected string _untampered_text;
        private string _contentText;

        public ElementText() : base()
        {
            ContentText = "NULL";
            _untampered_text = ContentText;
        }

        public ElementText(string text) : base()
        {
            ContentText = text;
            _untampered_text = ContentText;
        }

        public ElementText(string text, int px, int py) : base(px, py)
        {
            ContentText = text;
            _untampered_text = ContentText;
        }

        public override void Display()
        {
            int Temp_X = X;          
            base.Display();
            Console.BackgroundColor = BackgroundColor;
            Console.Write(ContentText);
            Console.BackgroundColor = ParentForm.BackgroundColor;
        }

        public string ContentText {
            get
            {
                return _contentText;
            }
            set
            {
                _contentText = value;
            }
        } //the text content of the element (e.g the string that it displays) 
    }
}
