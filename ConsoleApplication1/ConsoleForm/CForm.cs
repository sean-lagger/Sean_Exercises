using System;
using System.Collections.Generic;

namespace ConsoleForm
{
    public class CForm
    {

        private int _index = 0;
        private int _maxIndex = 0;

        public CForm()
        {
            SelectedIndex = 0;
        }

        public CForm(int c_width, int c_height):this()
        {
            Console.WindowWidth = c_width;
            Console.WindowHeight = c_height;
        }

        //Properties
        public List<Element> Elements = new List<Element>();
        public String FormName { get; set; }

        public int SelectedIndex {
            get
            {
                return _index;
            }
            set
            {
                if(value >= _maxIndex)
                {
                    _index = 0;
                }else if (value < 0)
                {
                    _index = _maxIndex - 1;
                }
                    else
                {
                    _index = value;
                }
                
            }
        }


        public string Selected
        {
            get
            {
                return Elements[SelectedIndex].ElementType;
            }
        }
        public void AddElement(Element e)
        {
            if(e.ElementType == "Selectable")
            {
                _maxIndex++;
            }

            e.ParentForm = this;
            Elements.Add(e);
        }

        public void Refresh() //Redraw all elements
        {
            Console.Clear();
            if(Selected != "Input")
            {
                Console.CursorVisible = false;
            }else
            {
                Console.CursorVisible = true;
            }
            foreach (Element e in Elements)
            {
                e.Display();
            }
        }

    }
}
