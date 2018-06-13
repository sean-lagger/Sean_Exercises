using System;
using System.Collections.Generic; // Lists
using ConsoleManipulation;
using ConsoleForm;

namespace ConsoleApplication1
{
    public class Program
    {
        public static CForm CurrentForm;
        public static CForm MainForm;

        public static void guessingGame(Exercise ex)
        {
            Console.Clear();
            Random rng = new Random();
            var Questions = new List<Question>();
            //Add new questions here
            Questions.Add(new Question("First name of the first man on the moon", "Neil"));
            Questions.Add(new Question("What color moves first in checkers?", "Black"));
            Questions.Add(new Question("On what continent is the Balkan Peninsula?", "Europe"));
            Questions.Add(new Question("What is the fear of darkness called?", "Scotophobia"));
            Questions.Add(new Question("What is the female version of the Duke title?", "Duchess"));
            
            //Elements
            //Question Field
            ElementText QuestionField = new ElementText();
            QuestionField.Y = 4;

            //Answer Input Field
            ElementInput AnswerField = new ElementInput(0);
            AnswerField.X = ConsoleManipulator.center(Console.WindowWidth, AnswerField.ContentText.Length);
            AnswerField.Y = 10;
            AnswerField.MaxInputLength = 2;
            AnswerField.ReplaceOnMax = true;

            //Blank Field
            ElementText BlankField = new ElementText();
            BlankField.Y = 7;

            //Error Field
            ElementText ErrorField = new ElementText();
            ErrorField.ContentText = "You have 3 Attempts Remaining";
            ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
            ErrorField.Y = 14;

            var GuessForm = new CForm(80, 20);
            GuessForm.AddElement(new ElementText("--Guessing Game--", ConsoleManipulator.center(Console.WindowWidth, "--Guessing Game--".Length), 1));
            GuessForm.AddElement(new ElementText("Press Escape to return to Main Menu", ConsoleManipulator.center(Console.WindowWidth, "Press Escape to return to Main Menu".Length), 18));
            GuessForm.AddElement(AnswerField);
            GuessForm.AddElement(QuestionField);
            GuessForm.AddElement(BlankField);
            GuessForm.AddElement(ErrorField);
            CurrentForm = GuessForm;
            
            int n = Questions.Count;
            int score = 0;
            bool escape = false;

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

                QuestionField.ContentText = Questions[n].Qst;
                QuestionField.X = ConsoleManipulator.center(Console.WindowWidth, QuestionField.ContentText.Length);
                BlankField.ContentText = new string(Questions[n].Blank);
                BlankField.X = ConsoleManipulator.center(Console.WindowWidth, BlankField.ContentText.Length);
                bool skip;
                bool isWrong = false;
                ErrorField.ContentText = "You have " + attempts + " Attempts Remaining";
                ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                CurrentForm.Refresh();

                while (attempts > 0 && Questions[n].isCompleted() == false)
                {

                    ConsoleKeyInfo PKey = Console.ReadKey(true);
                        if (PKey.Key == ConsoleKey.Backspace)
                        {
                            CurrentForm.popChar();
                        }
                        else if (Char.IsLetter(PKey.KeyChar))
                        {
                            CurrentForm.pushChar(PKey.KeyChar);
                        } else if (PKey.Key == ConsoleKey.Enter && AnswerField.Input != null && AnswerField.Input != String.Empty)
                        {
                            if (Questions[n].checkExists(AnswerField.Input[0]) == false)
                            {
                                --attempts;
                                ErrorField.ContentText = "You have " + attempts + " Attempts Remaining";
                            }
                            AnswerField.Input = "";
                        } else if (PKey.Key == ConsoleKey.Escape)
                        {
                            escape = true;
                            break;
                        }
                        
                        BlankField.ContentText = new string(Questions[n].Blank);
                        BlankField.X = ConsoleManipulator.center(Console.WindowWidth, BlankField.ContentText.Length);
                        AnswerField.X = ConsoleManipulator.center(Console.WindowWidth, AnswerField.ContentText.Length);

                        if (Questions[n].isCompleted())
                        {
                            score++;
                            ErrorField.ContentText = "Correct! Press Any Key to Proceed!";
                            ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                            CurrentForm.Refresh();
                            Console.ReadKey(true);
                            break;
                        }
                         CurrentForm.Refresh();
                }
                if(escape == true)
                {
                    break;
                }
            }
            if (!escape)
            {
                if (score > 0)
                {
                    ErrorField.ContentText = "Congratulations! You got " + score + " out of " + Questions.Count + " correct answers. Splendid Job!";
                }
                else
                {
                    ErrorField.ContentText = "You got " + score + " out of " + Questions.Count + " correct answers. Better luck next time!";
                }
                ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                CurrentForm.Refresh();
                Console.ReadKey(true);
            }
            CurrentForm = MainForm;
        }

        public static void stringConversion(Exercise ex)
        {

            var STCForm = new CForm(80, 10);
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
            MainForm = new CForm(80, 15);
            MainForm.AddElement(new ElementText("Sean's Exercises", ConsoleManipulator.center(Console.WindowWidth, "Sean's Exercises".Length) , 1));


                Console.Clear();
                //ConsoleManipulator.centerPrint("Sean's Exercises\n");
                ExerciseManager.Add(new Exercise("Guessing Game", guessingGame));
                ExerciseManager.Add(new Exercise("String Conversion", stringConversion));
            CurrentForm = MainForm;
            while (true)
            {
                CurrentForm.Refresh();
                ConsoleKeyInfo PKey = Console.ReadKey(true);
                if(PKey.Key == ConsoleKey.UpArrow)
                {
                    CurrentForm.SelectedIndex--;
                }else if(PKey.Key == ConsoleKey.DownArrow)
                {
                    CurrentForm.SelectedIndex++;
                }else if(Char.IsLetter(PKey.KeyChar) == true)
                {
                    CurrentForm.pushChar(PKey.KeyChar);
                }else if(PKey.Key == ConsoleKey.Enter)
                {
                    ExerciseManager.Pass(CurrentForm.SelectedIndex);
                }
                //while (ExerciseManager.Pass() == false) ;
            }
        }
    }
}
