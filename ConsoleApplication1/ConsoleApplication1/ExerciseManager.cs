using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleManipulation;
using ConsoleForm;

namespace ConsoleApplication1
{
    public static class ExerciseManager //Handles all the exercises I plan to add in the future
    {
        private static List<Exercise> ExList = new List<Exercise>();

        public static int ExCount = ExList.Count;

        public static void Add(Exercise exercise, CForm form) //Not much customizability here; DIP Design Smell
        {
            ElementSelectable es = new ElementSelectable(exercise.ExerciseName); //Dependency, change later
            double x = Console.WindowWidth / 2 - (es.ContentText.Length / 2);
            es.X = ConsoleManipulator.center(Console.WindowWidth, es.ContentText.Length);
            es.Y = 4 + ExList.Count() * 2; //HARDCODED Y CURSOR POSITION
            form.AddElement(es);
            ExList.Add(exercise);
        }

        public static bool Pass(int i)
        {
            ExList[i].runEx();
            return true;
        }

    }
}
