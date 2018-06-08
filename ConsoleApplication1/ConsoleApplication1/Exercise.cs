using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Exercise
    {
        public Exercise(string name, Action run)
        {
            ExerciseName = name;
            runEx = run;
        }

        //Properties
        public string ExerciseName { get; }

        public Action runEx;
    }
}
