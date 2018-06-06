using System;
using System.Collections.Generic; // Lists

namespace ConsoleApplication1
{
    public class Program
    {

        

        public static void centerPrint(string toPrint) //Prints text on the center of the console
        {
            double x = (Console.WindowWidth / 2) - (toPrint.Length / 2);
            string init = "";
            for (int i = 0; i < Math.Ceiling(x); i++)
            {
                init += " ";
            }

            Console.WriteLine(init + toPrint);
        }

        public static void guessingGame()
        {
            Random rng = new Random();
            var Questions = new List<Question>();
            //Add new questions here
            Questions.Add(new Question("First name of the first man on the moon", "Neil"));
            Questions.Add(new Question("What color moves first in checkers?", "Black"));
            Questions.Add(new Question("On what continent is the Balkan Peninsula?", "Europe"));
            Questions.Add(new Question("What is the fear of darkness called?", "Scotophobia"));
            Questions.Add(new Question("What is the female version of the Duke title?", "Duchess"));

            centerPrint("Guessing Game!\n");

            int n = Questions.Count;
            int score = 0;

            while (n > 0)
            {
                int attempts = 3;
                int k = rng.Next(n--);

                //Shuffle and display list elements
                //Displays as it shuffles
                string entered;
                var temp = Questions[k];
                Questions[k] = Questions[n];
                Questions[n] = temp;
                Questions[n].display();

                while (attempts > 0 && Questions[n].isCompleted() == false)
                {
                    Console.Write("> ");
                    entered = Console.ReadLine();
                    if (entered.Length != 1)
                    {
                        Console.WriteLine("Please input only 1 character");
                    }
                    else if (Questions[n].checkExists(entered[0]) == false)
                    {
                        Console.WriteLine("Wrong Answer. You have " + --attempts + " attempt(s) remaining.\n");
                    }

                    Questions[n].display();
                    if (Questions[n].isCompleted())
                        score++;

                }
            }

            centerPrint("You got " + score + " out of " + Questions.Count + " questions correct!");
        }

        public static void stringConversion()
        { 
            centerPrint("Hello and welcome to the string conversion program!");
            centerPrint("Input a string and I will convert the alternating characters into their inverse cases.");
            Console.Write("> ");
            char[] input = Console.ReadLine().ToCharArray();
            int offset = 0;

            if (Char.IsUpper(input[0]) && Char.IsLetter(input[0]))
            {
                offset = 1;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if(offset%2 == 0 && Char.IsLetter(input[i]))
                {
                    input[i] = Char.ToUpper(input[i]);
                }else
                {
                    input[i] = Char.ToLower(input[i]);
                }

               if(Char.IsLetter(input[i]))
                    offset++;
            }
            Console.WriteLine();
            centerPrint(new string(input));
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                centerPrint("Sean's Exercises\n");
                var exm = new ExerciseManager();
                exm.add(new Exercise("Guessing Game", guessingGame));
                exm.add(new Exercise("String Conversion", stringConversion));
                exm.display();
                while (exm.pass() == false) ;
            }
        }


    }

    public class Question
    {
        public Question(string inquiry, string ans)
        {
            CorrectAnswers = 0;
            Qst = inquiry;
            Answer = ans;
            Blank = new char[Answer.Length * 2];
            for (int i = 0; i < Blank.Length; i++)
            {
                if (i % 2 == 0)
                    Blank[i] = '_';
                else
                    Blank[i] = ' ';
            }
        }

        private string Qst { get; set; }
        private int CorrectAnswers { get; set; }

        private string Answer { get; set; }

        private char[] Blank { get; set; }

        public void display()
        {
            Program.centerPrint(Qst + "\n");
            Program.centerPrint(new string(Blank) + "\n");
        }

        public bool checkExists(char a )
        {
            bool has_character = false;
            char testChar = Char.ToLower(a);
            for (int i = 0; i< Answer.Length; i++)
            {
                string lowerAnswer = Answer.ToLower();
                if(lowerAnswer[i] == testChar && testChar != Char.ToLower(Blank[i * 2]))
                {
                    has_character = true;
                    Blank[i * 2] = Answer[i];
                    CorrectAnswers++;
                }

            }

            return has_character;
        }

        public bool isCompleted()
        {
            if(CorrectAnswers == Answer.Length)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }

    public class Exercise
    {
        public Exercise(string name, Action run)
        {
            ExerciseName = name;
            runEx = run;
        }

        public string ExerciseName { get; }
        public Action runEx;        
    }

    public class ExerciseManager //Handles all the exercises I plan to add in the future
    {
        private List<Exercise> ExList = new List<Exercise>();

        public void add(Exercise exercise)
        {
            ExList.Add(exercise);
        }

        public void display()
        {
            for(int i = 0; i<ExList.Count; i++)
            {
                Program.centerPrint("["+ (i+1) + "] " + ExList[i].ExerciseName + "\n");
            }
        }

        public bool pass()
        {
            try {
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
            } catch (Exception e) {
                Console.WriteLine("Unknown Input. Try again.");
                return false;
            }
            return true;
        }
    }
}
