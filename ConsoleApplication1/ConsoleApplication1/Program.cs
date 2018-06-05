using System;
using System.Collections.Generic; // Lists

//Attempting to apply everything I've learned so far (OOP STYLE).
//Branch Test
//Test Credentials

namespace ConsoleApplication1
{
    class Program
    {

        private static Random rng = new Random();

        public static void centerPrint(string toPrint)
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
            string again = "y";
            while (again == "y")
            {
                Console.Clear();
                List<Question> Questions = new List<Question>();
                //Add new questions here

                Questions.Add(new Question("First name of the first man on the moon", "Neil"));
                Questions.Add(new Question("What color moves first in checkers?", "Black"));
                Questions.Add(new Question("On what continent is the Balkan Peninsula?", "Europe"));
                Questions.Add(new Question("First name of the first man on the moon", "Neil"));
                Questions.Add(new Question("What color moves first in checkers?", "Black"));
                Questions.Add(new Question("On what continent is the Balkan Peninsula?", "Europe"));

                centerPrint("Guessing Game!\n");

                

                int n = Questions.Count;
                int score = 0;

                while (n > 0)
                {
                    int attempts = 3;
                    int k = rng.Next(n--);
                    //Shuffle and display list elements
                    string entered;
                    Question temp = Questions[k];
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
                centerPrint("Would you like to try again? Input 'y' if so.");
                while (again != "y" || again != "n") { again = Console.ReadLine(); }
            }
        }

        public static void stringConversion()
        {
            string again = "y";
            while (again == "y")
            {
                again = "a";
                Console.Clear();
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
                centerPrint("Would you like to try again? Input 'y' if so, 'n' if not.");
                while (again != "y" && again != "n") { Console.Write("> "); again = Console.ReadLine(); Console.WriteLine("Unknown Input. Try again."); }
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                centerPrint("Sean's Exercises\n");
                ExerciseManager exm = new ExerciseManager();
                exm.add(new Exercise("Guessing Game", guessingGame));
                exm.add(new Exercise("String Conversion", stringConversion));
                exm.display();
                while (exm.pass() == false) ;
            }
        }


    }

    class Question
    {
        private string qst;
        private string answer;
        private char[] blank;
        private int correctAnswers = 0;
        public Question(string inquiry, string ans)
        {
            qst = inquiry;
            answer = ans;
            blank = new char[answer.Length * 2];
            for (int i = 0; i < blank.Length; i++)
            {
                if (i % 2 == 0)
                    blank[i] = '_';
                else
                    blank[i] = ' ';
            }
        }

        public int getQLen()
        {
            return answer.Length;
        }

        public void display()
        {
            Program.centerPrint(qst + "\n");
            Program.centerPrint(new string(blank) + "\n");
        }

        public bool checkExists(char a )
        {
            bool has_character = false;
            char testChar = Char.ToLower(a);
            for (int i = 0; i< answer.Length; i++)
            {
                string lowerAnswer = answer.ToLower();
                if(lowerAnswer[i] == testChar && testChar != Char.ToLower(blank[i * 2]))
                {
                    has_character = true;
                    blank[i * 2] = answer[i];
                    correctAnswers++;
                }

            }

            return has_character;
        }

        public bool isCompleted()
        {
            if(correctAnswers == answer.Length)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }

    class Exercise
    {
        private string exerciseName;
        public Action runEx;

        public Exercise(string name, Action run)
        {
            exerciseName = name;
            runEx = run;
        }

        public string getName()
        {
            return exerciseName;
        }
        
    }



    class ExerciseManager //Handles all the exercises I plan to add in the future
    {
        private List<Exercise> ex = new List<Exercise>();

        public ExerciseManager()
        {

        }

        public void add(Exercise exercise)
        {
            ex.Add(exercise);
        }

        public void display()
        {
            for(int i = 0; i<ex.Count; i++)
            {
                Program.centerPrint("["+ (i+1) + "] " + ex[i].getName() + "\n");
            }
        }

        public bool pass()
        {
            try {
                int i = int.Parse(Console.ReadLine());
                ex[(i-1)].runEx();
            } catch (Exception e) {
                Console.WriteLine("Unknown Input. Try again.");
                return false;
            }
            return true;
        }
    }


}
