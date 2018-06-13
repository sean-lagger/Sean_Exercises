using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementInput : ElementSelectable
    {
        ElementInput(int index) : base(index)
        {
            ElementType = "Input";
            Input = "";
        }

        public override void Display()
        {
            ContentText = ">" + Input + "<";
            X -= 2;
            base.Display();
        }

        public string Input { get; set; }

    }
}
