using System;
using System.Collections.Generic; // Lists
using ConsoleManipulation;
using ConsoleForm;

namespace ConsoleApplication1
{
    public class Program
    {
        public static CForm MainForm;

        public static void guessingGame(Exercise ex)
        {
            Random rng = new Random();
            var Questions = new List<Question>();
            //Add new questions here
            Questions.Add(new Question("First name of the first man on the moon", "Neil"));
            Questions.Add(new Question("What color moves first in checkers?", "Black"));
            Questions.Add(new Question("On what continent is the Balkan Peninsula?", "Europe"));
            Questions.Add(new Question("What is the fear of darkness called?", "Scotophobia"));
            Questions.Add(new Question("What is the female version of the Duke title?", "Duchess"));


            ConsoleManipulator.centerPrint("Guessing Game!\n");

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

            ConsoleManipulator.centerPrint("You got " + score + " out of " + Questions.Count + " questions correct!");
        }

        public static void stringConversion(Exercise ex)
        {
            ConsoleManipulator.centerPrint("Hello and welcome to the string conversion program!");
            ConsoleManipulator.centerPrint("Input a string and I will convert the alternating characters into their inverse cases.");
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
            ConsoleManipulator.centerPrint(new string(input));
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //Initialize Form Configs





            while (true)
            {
                Console.Clear();
                ConsoleManipulator.centerPrint("Sean's Exercises\n");
                ExerciseManager.Add(new Exercise("Guessing Game", guessingGame));
                ExerciseManager.Add(new Exercise("String Conversion", stringConversion));
                ExerciseManager.Display();
                while (ExerciseManager.Pass() == false) ;
            }
        }


    }

    

    
}
