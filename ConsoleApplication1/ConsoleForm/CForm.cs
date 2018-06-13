using System;
using System.Collections.Generic;

namespace ConsoleForm
{
    public class CForm
    {
        public CForm()
        {

        }

        public CForm(int c_width, int c_height)
        {
            Console.WindowWidth = c_width;
            Console.WindowHeight = c_height;
        }

        //Properties
        public List<Element> Elements = new List<Element>();
        public String FormName { get; set; }

        public void AddElement(Element e)
        {
            Elements.Add(e);
        }

    }
}
