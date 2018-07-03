using System;
using System.Collections.Generic;

namespace ConsoleForm
{
    public class CForm
    {

        private int _index = 0;


        public CForm()
        {
            SelectedIndex = 0;
            Console.CursorVisible = false;
            BackgroundColor = ConsoleColor.Black;
            FormKeyHandler = new ConsoleForm.KeyHandler();
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

        public static List<int> UpdatedRows = new List<int>(); //**UNIMPLEMENTED

        public String FormName { get; set; }

        public int SelectedIndex {
            get
            {
                return _index;
            }
            set
            {
                if (value >= Selectables.Count)
                {
                    _index = 0;
                } else if (value < 0)
                {
                    _index = Selectables.Count - 1;
                }
                else
                {
                    _index = value;
                }

            }
        }

        public void moveNext()
        {
            ++SelectedIndex;
            while (!SelectedElement.isEnabled)
            {
                SelectedIndex++;
            }
        }

        public void movePrevious()
        {
            --SelectedIndex;
            while (!SelectedElement.isEnabled)
            {
                SelectedIndex--;
            }
        }

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor SelectedColor { get; set; }
        public KeyHandler FormKeyHandler { get; set; }
        
        public FormHolder Holder { get; set; }


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
            if (e is ElementSelectable)
            {
                Selectables.Add(e as ElementSelectable);
            }
            Elements.Add(e);
            e.onUpdate();
            e.BackgroundColor = this.BackgroundColor;

        }

        public void AddElement(IEnumerable<Element> collection)
        {
            foreach(Element e in collection)
            {
                AddElement(e);
            }
        }


        public bool pushChar(char key) //The Form pushes a char value onto the selected element (ElementInput)
        {
            if (SelectedElement is ElementInput && (Char.IsLetterOrDigit(key) || Char.IsSymbol(key) || Char.IsSeparator(key) || Char.IsPunctuation(key)))
            {
                (SelectedElement as ElementInput).Input += key;
                return true;
            }
            return false;
        }

        public void popChar() //Simulates a backspace on the selected input;
        {

            if (SelectedElement is ElementInput)
            {
                ElementInput input = SelectedElement as ElementInput;
                if (input.Input.Length > 0 && input.ReplaceOnMax != true)
                {
                    input.Input = input.Input.Remove(input.Input.Length - 1);
                }

            }
        }

        public void AwaitKey()
        {
            FormKeyHandler.PassKey(Console.ReadKey(true));

        }

        public void RemoveElement(Element e)
        {
            Elements.Remove(e);

            if (e is ElementSelectable)
            {
                Selectables.Remove(Selectables.Find(r => r.ID == e.ID));
            }

        }

        public void Clear(Element e)
        {
            Elements.Clear();
        }

        public void UpdateRow(int i)
        {
            UpdatedRows.Add(i);
        }

        public void Refresh() //Redraw all elements
        {
            Console.BackgroundColor = BackgroundColor;
            if (Console.WindowWidth != Width || Console.WindowHeight != Height)
            {
                Console.WindowWidth = Width;
                Console.WindowHeight = Height;
            }

            string toDelete = new string(' ', Console.WindowWidth);

            if (Holder.HasSwitched)
            {
                Holder.HasSwitched = false;
                Console.Clear();
            }
            
            foreach (int i in UpdatedRows)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = i;
                Console.Write(toDelete);
            }

      

            UpdatedRows.Clear();
            //Console.Clear();

            foreach (Element e in Elements)
            {
                e.Display();
            }

        }


    }
}
