using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManipulation
{
    public static class ConsoleManipulator
    {
        public static void centerPrint(string toPrint) //Prints text on the center of the console ## Could be a reusable library component
        {
            double x = (Console.WindowWidth / 2) - (toPrint.Length / 2);
            string init = "";
            for (int i = 0; i < Math.Ceiling(x); i++)
            {
                init += " ";
            }

            Console.WriteLine(init + toPrint);
        }

        public static int center(double width, double length)
        {
            double field = (width / 2) - (length / 2);
            return (int)Math.Ceiling(field);
        }

        public static void EntryField()
        {

        }
    }
}
