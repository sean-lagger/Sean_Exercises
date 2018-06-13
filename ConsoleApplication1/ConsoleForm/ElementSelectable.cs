using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementSelectable : ElementText
    {
        public ElementSelectable(int index): base()
        {
            ElementType = "Selectable";
            Index = index;
        }

        public ElementSelectable(int index, string _text) : base(_text)
        {
            Index = index;
            ElementType = "Selectable";
        }

        public int Index { get; private set; } 

        public override void Display()
        {
            int Temp_X = X;
            if (ParentForm.SelectedIndex == Index)
            {
                ContentText = "[" + _text + "]";
                X -= 1;
            }else
            {
                ContentText = _text;
            }
            base.Display();
            X = Temp_X;
        }

        public virtual void Activate<T> (Action<T> toRun)
        {
            
        }
    }
}
