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
            Console.CursorVisible = false;
        }

        public CForm(int c_width, int c_height) : this()
        {
            Width = c_width;
            Height = c_height;
            Console.WindowWidth = Width;
            Console.WindowHeight = Height;
        }

        //Properties
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Element> Elements = new List<Element>();
        private List<ElementSelectable> Selectables = new List<ElementSelectable>();
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
                return Selectables[SelectedIndex].ElementType;
            }
        }

        public Element SelectedElement
        {
            get
            {
                return Selectables[SelectedIndex];
            }
        }

        public void AddElement(Element e)
        {
            e.ParentForm = this;
            if (e.ElementType == "Selectable" || e.ElementType == "Input")
            {
                _maxIndex++;
                Selectables.Add(e as ElementSelectable);
            }

           
            Elements.Add(e);
        }

        public void pushChar (char key)
        {
            if (Selected == "Input")
            {
                ElementInput input = SelectedElement as ElementInput;
                input.Input += key;

            }
        }

        public void popChar()
        {
            ElementInput input = SelectedElement as ElementInput;
            if (Selected == "Input" && input.Input.Length > 0 && input.ReplaceOnMax != true)
            {
                input.Input = input.Input.Remove(input.Input.Length - 1);
            }
        }

        public void Refresh() //Redraw all elements
        {
            if (Console.WindowWidth != Width || Console.WindowHeight != Height)
            {
                Console.WindowWidth = Width;
                Console.WindowHeight = Height;
            }
            Console.Clear();
            foreach (Element e in Elements)
            {
                e.Display();
            }

        }

    }
}
