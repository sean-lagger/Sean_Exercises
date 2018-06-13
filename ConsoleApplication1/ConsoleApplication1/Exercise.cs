using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForm;
namespace ConsoleApplication1
{
    public class Exercise
    {
        public Exercise(string name, Action<Exercise> run)
        {
            ExerciseName = name;
            runEx = run;
        }

        //Properties
        public string ExerciseName { get; }
        public CForm ExForm { get; set; }

        public Action<Exercise> runEx;
    }
}
