using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class ExerciseManager //Handles all the exercises I plan to add in the future ## In consideration to be reusable
    {
        private static List<Exercise> ExList = new List<Exercise>();

        public static void add(this Exercise exercise)
        {
            ExList.Add(exercise);
        }

        public static void display()
        {
            for (int i = 0; i < ExList.Count; i++)
            {
                Program.centerPrint("[" + (i + 1) + "] " + ExList[i].ExerciseName + "\n");
            }
        }

        public static bool pass()
        {
            try
            {
                Console.Write("> ");
                int i = int.Parse(Console.ReadLine());
                string again = "y";
                while (again == "y")
                {
                    again = null;
                    Console.Clear();
                    ExList[(i - 1)].runEx();
                    Program.centerPrint("Would you like to try again? Input 'y' if so.");
                    while (again != "y" && again != "n") { Console.Write("> "); again = Console.ReadLine(); Console.WriteLine("Unknown Input. Try again."); }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown Input. Try again.");
                return false;
            }
            return true;
        }
    }
}
