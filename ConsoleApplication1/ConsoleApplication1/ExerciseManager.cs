using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleManipulation;
using ConsoleForm;

namespace ConsoleApplication1
{
    public static class ExerciseManager //Handles all the exercises I plan to add in the future ## In consideration to be reusable
    {
        private static List<Exercise> ExList = new List<Exercise>();

        public static int ExCount = ExList.Count;

        public static void Add(Exercise exercise)
        {
            ElementSelectable es = new ElementSelectable(ExList.Count, exercise.ExerciseName);
            double x = Console.WindowWidth / 2 - (es.ContentText.Length / 2);
            es.X = ConsoleManipulator.center(Console.WindowWidth, es.ContentText.Length);
            es.Y = 4 + ExList.Count() * 2;
            es.Centered = true;
            Program.MainForm.AddElement(es);
            ExList.Add(exercise);
        }

        public static void Display()
        {
            for (int i = 0; i < ExList.Count; i++)
            {
                ConsoleManipulator.centerPrint("[" + (i + 1) + "] " + ExList[i].ExerciseName + "\n");
            }
        }

        public static bool Pass()
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
                    Program.MainForm = ExList[(i - 1)].ExForm;
                    ExList[(i - 1)].runEx(ExList[(i - 1)]);
                    ConsoleManipulator.centerPrint("Would you like to try again? Input 'y' if so.");
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
