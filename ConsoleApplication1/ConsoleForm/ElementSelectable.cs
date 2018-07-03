using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementSelectable : ElementText
    {
        public ElementSelectable(): base()
        {
            ElementType = "Selectable";
        }

        public ElementSelectable( string _text) : base(_text)
        {
            ElementType = "Selectable";
        }


        public ElementSelectable(string _text, int px, int py) : base(_text)
        {
            ElementType = "Selectable";
            X = px;
            Y = py;
        }

        //Properties
        public int Index { get; private set; }

        public int SelectedReturn { get; set; } //Rudimentary on_select return value;

        public override void Display()
        {
            int Temp_X = X;
            if (ParentForm.SelectedElement == this)
            {
                this.BackgroundColor = ParentForm.SelectedColor;
                ContentText = "[" + _untampered_text + "]";
                X -= 1;
            }else
            {
                this.BackgroundColor = ParentForm.BackgroundColor;
                ContentText = _untampered_text;
            }
            
            base.Display();
            X = Temp_X;
        }

    }
}
