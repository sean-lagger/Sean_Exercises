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
            bool again = true;
            while (again == true)
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
                ElementInput AnswerField = new ElementInput();
                AnswerField.X = ConsoleManipulator.center(Console.WindowWidth, AnswerField.ContentText.Length);
                AnswerField.Y = 10;
                AnswerField.MaxInputLength = 2;
                AnswerField.ReplaceOnMax = true;
                AnswerField.isEnabled = true;

                //Blank Field
                ElementText BlankField = new ElementText();
                BlankField.Y = 7;

                //Error Field
                ElementText ErrorField = new ElementText();
                ErrorField.ContentText = "You have 3 Attempts Remaining";
                ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                ErrorField.Y = 14;

                var GuessForm = new CForm(80, 20);
                GuessForm.BackgroundColor = ConsoleColor.DarkCyan;
                GuessForm.AddElement(new ElementText("--Guessing Game--", ConsoleManipulator.center(Console.WindowWidth, "--Guessing Game--".Length), 1));
                GuessForm.AddElement(new ElementText("Press Escape to return to Main Menu", ConsoleManipulator.center(Console.WindowWidth, "Press Escape to return to Main Menu".Length), 18));

                GuessForm.AddElement(AnswerField);
                GuessForm.AddElement(QuestionField);
                GuessForm.AddElement(BlankField);
                GuessForm.AddElement(ErrorField);

                bool escape = false;
                bool hasEntered = false;
                GuessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Enter, () => { hasEntered = true; }));
                GuessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Escape, () => { escape = true; }));
                GuessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.LeftArrow, () => { CurrentForm.movePrevious(); }));
                GuessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.RightArrow, () => { CurrentForm.moveNext(); }));
                GuessForm.FormKeyHandler.Register(new KeyEvent((char a) => { if (Char.IsLetter(a)) { GuessForm.pushChar(a); hasEntered = false; } }, true));

                GuessForm.SelectedColor = ConsoleColor.DarkYellow;
                CurrentForm = GuessForm;

                int n = Questions.Count;
                int score = 0;


                while (n > 0)
                {
                    int attempts = 3;
                    int k = rng.Next(n--);

                    //Shuffle and display list elements
                    //Displays as it shuffles
                    var temp = Questions[k];
                    Questions[k] = Questions[n];
                    Questions[n] = temp;

                    QuestionField.ContentText = Questions[n].Qst;
                    QuestionField.X = ConsoleManipulator.center(Console.WindowWidth, QuestionField.ContentText.Length);
                    BlankField.ContentText = new string(Questions[n].Blank);
                    BlankField.X = ConsoleManipulator.center(Console.WindowWidth, BlankField.ContentText.Length);
                    ErrorField.ContentText = "You have " + attempts + " Attempts Remaining";
                    ErrorField.BackgroundColor = ErrorField.ParentForm.BackgroundColor;
                    ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);

                    CurrentForm.Refresh();

                    while (attempts > 0 && Questions[n].isCompleted() == false)
                    {

                        CurrentForm.AwaitKey();
                        if (hasEntered && AnswerField.Input != null && AnswerField.Input != String.Empty)
                        {
                            if (Questions[n].checkExists(AnswerField.Input[0]) == false)
                            {
                                --attempts;
                                ErrorField.ContentText = "You have " + attempts + " Attempts Remaining";
                                if (attempts == 2)
                                    ErrorField.BackgroundColor = ConsoleColor.DarkYellow;
                                else if (attempts == 1)
                                    ErrorField.BackgroundColor = ConsoleColor.DarkRed;
                            }
                            AnswerField.Input = "";
                            hasEntered = false;
                        }

                        if (escape) { break; }

                        BlankField.ContentText = new string(Questions[n].Blank);
                        BlankField.X = ConsoleManipulator.center(Console.WindowWidth, BlankField.ContentText.Length);
                        AnswerField.X = ConsoleManipulator.center(Console.WindowWidth, AnswerField.ContentText.Length);

                        if (Questions[n].isCompleted())
                        {
                            score++;
                            ErrorField.ContentText = "Correct! Press Any Key to Proceed!";
                            ErrorField.BackgroundColor = ConsoleColor.DarkGreen;
                            ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                            CurrentForm.Refresh();
                            Console.ReadKey(true);
                            break;
                        }

                        CurrentForm.Refresh();
                    }

                    if (escape == true)
                    {
                        break;
                    }

                    if (!Questions[n].isCompleted())
                    {
                        ErrorField.ContentText = "Wrong Answer! You've used up all your attempts.";
                        ErrorField.BackgroundColor = ConsoleColor.DarkRed;
                        ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
                        CurrentForm.Refresh();
                        Console.ReadKey(true);
                    }

                }
                if (!escape)
                {
                    if (score > 0)
                    {
                        ErrorField.BackgroundColor = ConsoleColor.DarkGreen;
                        ErrorField.ContentText = "Congratulations! You got " + score + " out of " + Questions.Count + " correct answers. Splendid Job!";
                    }
                    else
                    {
                        ErrorField.BackgroundColor = ConsoleColor.DarkRed;
                        ErrorField.ContentText = "You got " + score + " out of " + Questions.Count + " correct answers. Better luck next time!";
                    }

                    ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);

                    AnswerField.isEnabled = false;

                    

                    ElementSelectable TryAgain_Yes = new ElementSelectable("Yes");
                    TryAgain_Yes.X = 4;
                    TryAgain_Yes.Y = 18;
                    TryAgain_Yes.SelectedReturn = 1;

                    ElementSelectable TryAgain_No = new ElementSelectable("No");
                    TryAgain_No.X = 70;
                    TryAgain_No.Y = 18;
                    TryAgain_No.SelectedReturn = 2;

                    CurrentForm.AddElement(TryAgain_Yes);
                    CurrentForm.AddElement(TryAgain_No);
                    CurrentForm.AddElement(new ElementText("             Try Again?             ", ConsoleManipulator.center(Console.WindowWidth, "             Try Again?             ".Length), 18 ));
                    CurrentForm.moveNext();

                    int selected = 0;

                    GuessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Enter, () => { selected = (CurrentForm.SelectedElement as ElementSelectable).SelectedReturn; }));

                    while (selected == 0)
                    {
                        CurrentForm.Refresh();
                        CurrentForm.AwaitKey();
                    }

                    if (selected == 1)
                    { again = true; }
                    else
                        again = false;

                }else
                {
                    again = false;
                }

            }
            CurrentForm = MainForm;
            
        }

        public static void stringConversion(Exercise ex)
        {

            var STCForm = new CForm(100, 11);
            CurrentForm = STCForm;

            //Input
            ElementInput InputField = new ElementInput();
            InputField.X = ConsoleManipulator.center(Console.WindowWidth, InputField.ContentText.Length);
            InputField.Y =7;
            InputField.MaxInputLength = 82;

            //Result
            ElementText ErrorField = new ElementText();
            ErrorField.ContentText = " ";
            ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);
            ErrorField.Y = 5;

            STCForm.BackgroundColor = ConsoleColor.DarkCyan;
            STCForm.SelectedColor = ConsoleColor.DarkYellow;

            STCForm.AddElement(new ElementText("String Conversion Program", ConsoleManipulator.center(Console.WindowWidth, "String Conversion Program".Length), 1));
            STCForm.AddElement(new ElementText("Input a string and I will convert the alternating characters into their inverse cases.", ConsoleManipulator.center(Console.WindowWidth, "Input a string and I will convert the alternating characters into their inverse cases.".Length), 2));
            STCForm.AddElement(new ElementText("Press the ESC Key to return to the Main Menu", ConsoleManipulator.center(Console.WindowWidth, "Press the ESC Key to return to the Main Menu".Length), 9));
            STCForm.AddElement(InputField);
            STCForm.AddElement(ErrorField);

            bool escape = false;
            bool hasInput = false;
            STCForm.FormKeyHandler.Register(new KeyEvent((char a) => {if(CurrentForm.pushChar(a)) hasInput = true;}, true));
            STCForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Backspace, () => { CurrentForm.popChar(); hasInput = true; }));
            STCForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Escape, () => { escape = true; }));

            ErrorField.BackgroundColor = ConsoleColor.DarkRed;
            CurrentForm.Refresh();

            while (escape == false)
            {
                hasInput = false;
                CurrentForm.AwaitKey();

                InputField.X = ConsoleManipulator.center(Console.WindowWidth, InputField.ContentText.Length);
                if (hasInput)
                {
                    char[] input = InputField.Input.ToCharArray();
                    int offset = 0;

                    if (input.Length > 0)
                        if (Char.IsUpper(input[0]) && Char.IsLetter(input[0]))
                        {
                            offset = 1;
                        }

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (offset % 2 == 0 && Char.IsLetter(input[i]))
                        {
                            input[i] = Char.ToUpper(input[i]);
                        }
                        else
                        {
                            input[i] = Char.ToLower(input[i]);
                        }

                        if (Char.IsLetter(input[i]))
                            offset++;
                    }

                    ErrorField.ContentText = new string(input);
                    ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, input.Length);
                }
                CurrentForm.Refresh();
            }


            CurrentForm.Refresh();
            CurrentForm = MainForm;

        }

        static void Main(string[] args)
        {
            //Initialize Form Configs
            MainForm = new CForm(80, 15);
            MainForm.BackgroundColor = ConsoleColor.DarkBlue;
            MainForm.SelectedColor = ConsoleColor.Red;

            var Title_Element = new ElementText("Sean's Exercises", ConsoleManipulator.center(Console.WindowWidth, "Sean's Exercises".Length), 1);
            MainForm.AddElement(Title_Element);
            ExerciseManager.Add(new Exercise("Guessing Game", guessingGame), MainForm);
            ExerciseManager.Add(new Exercise("String Conversion", stringConversion), MainForm);

            var Input_Element = new ElementInput();
            Input_Element.MaxInputLength = 6;
            Input_Element.X = 1;
            Input_Element.Y = 14;
            MainForm.AddElement(Input_Element);

            MainForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.DownArrow, () =>{ CurrentForm.moveNext(); }));
            MainForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.UpArrow, () => { CurrentForm.movePrevious(); }));
            MainForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Enter, () => { if (CurrentForm.SelectedElement.ElementType != "Input") { ExerciseManager.Pass(CurrentForm.SelectedIndex); }; }));
            MainForm.FormKeyHandler.Register(new KeyEvent((char a) => { MainForm.pushChar(a); } , true));
            MainForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Backspace, () => { MainForm.popChar(); }));
            MainForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Delete, () => { MainForm.RemoveElement(Input_Element); }));

            CurrentForm = MainForm;
            CurrentForm.Refresh();

            while (true)
            {
                CurrentForm.AwaitKey();
                CurrentForm.Refresh();
            }
            
        }
    }
}
