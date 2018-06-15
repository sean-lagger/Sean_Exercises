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
            BackgroundColor = ConsoleColor.Black;
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

        private List<Element> Elements = new List<Element>();
        private List<Element> Selectables = new List<Element>();

        public static List<int> UpdatedRows = new List<int>();

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

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor SelectedColor { get; set; }

        

        public string SelectedType
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
            e.BackgroundColor = BackgroundColor;
            Elements.Add(e); 
        }

        public void RemoveElement(int _id)
        {
            foreach(Element e in Elements)
            {

            }
        }

        public void pushChar (char key) //The Form pushes a char value onto the selected element (ElementInput)
        {
            if (SelectedType == "Input")
            {
                ElementInput input = SelectedElement as ElementInput;
                input.Input += key;

            }
        }

        public void popChar() //Simulates a backspace on the selected input;
        {
            
            if (SelectedType == "Input")
            {
                ElementInput input = SelectedElement as ElementInput;
                if (input.Input.Length > 0 && input.ReplaceOnMax != true)
                {
                    input.Input = input.Input.Remove(input.Input.Length - 1);
                }
                
            }
        }

        public void Refresh() //Redraw all elements
        {
            Console.BackgroundColor = BackgroundColor;
            if (Console.WindowWidth != Width || Console.WindowHeight != Height)
            {
                Console.WindowWidth = Width;
                Console.WindowHeight = Height;
            }

            Console.Clear();

            /*if (CForm.UpdatedRows.Count > 0)
            {
                for (int i = 0; i < CForm.UpdatedRows.Count; i++)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = CForm.UpdatedRows[i];
                    Console.Write(new string(' ', Console.WindowWidth));
                    CForm.UpdatedRows.Clear();
                }
            }*/

            foreach (Element e in Elements)
            {
                e.Display();
            }

        }

    }
}
