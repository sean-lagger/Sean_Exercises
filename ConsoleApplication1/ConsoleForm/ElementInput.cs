using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class ElementInput : ElementSelectable
    {
        private string _input;

        public ElementInput(int index) : base(index)
        {
            _text = " ";
            ElementType = "Input";
            Input = "";
        }

        public string Input
        {
            get
            {
                return _input;
            }

            set
            {
                if(value.Length < MaxInputLength)
                {
                    _input = value;
                }else
                {
                    if (ReplaceOnMax)
                    {
                        _input = value[1].ToString();
                    }
                }
            }
        }

        public int MaxInputLength { get; set; }
        public bool ReplaceOnMax { get; set; } //Replace Input field with next character once the Maximum input length has been reached (Designed for Guessing Game) else, Input field will not accept any more inputs.
        public bool Eraseable { get; set; } //Whether or not the user can backspace;

        public override void Display()
        {
            _text = ">" + Input + "<";
            base.Display();
        }



    }
}
