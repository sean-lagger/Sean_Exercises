using System;
using System.IO;
using System.Collections.Generic; // Lists
using ConsoleManipulation;
using ConsoleForm;

namespace ConsoleApplication1
{
    public class Program
    {    
        public static CForm MainForm;
        public static FormHolder MainFormHolder = new FormHolder(MainForm);

        public static void guessingGame()
        {
            bool again = true;
            var path = Directory.GetCurrentDirectory() + "\\qanda.csv";
            var questions = new List<Question>();

            try
            {
                using (var reader = new StreamReader(@path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        questions.Add(new Question(values[0], values[1]));

                    }
                }
            }
            catch (FileNotFoundException e)
            {
                again = false;
                Console.Clear();
                Console.WriteLine("CSV FILE NOT FOUND!");
                Console.ReadKey(true);
            }
           
            while (again == true)
            {
                Console.Clear();
                Random rng = new Random();
               
                //Elements
                //Question Field
                ElementText questionField = new ElementText();
                questionField.Y = 4;

                //Answer Input Field
                ElementInput answerField = new ElementInput();
                answerField.X = ConsoleManipulator.center(Console.WindowWidth, answerField.ContentText.Length);
                answerField.Y = 10;
                answerField.MaxInputLength = 2;
                answerField.ReplaceOnMax = true;
                answerField.isEnabled = true;

                //Blank Field
                ElementText blankField = new ElementText();
                blankField.Y = 7;

                //Error Field
                ElementText errorField = new ElementText("You have 3 Attempts Remaining", 0 , 14);
                errorField.X = ConsoleManipulator.center(Console.WindowWidth, errorField.ContentText.Length);


                var guessForm = new CForm(80, 20);
                guessForm.BackgroundColor = ConsoleColor.DarkCyan;
                guessForm.AddElement(new Element[] { answerField, questionField, blankField, errorField,
                    new ElementText("--Guessing Game--", ConsoleManipulator.center(Console.WindowWidth, "--Guessing Game--".Length), 1),
                    new ElementText("Press Escape to return to Main Menu", ConsoleManipulator.center(Console.WindowWidth, "Press Escape to return to Main Menu".Length), 18) });

                bool escape = false;
                bool hasEntered = false;
                guessForm.FormKeyHandler.Register(new KeyEvent[] { new KeyEvent(ConsoleKey.Enter, () => { hasEntered = true; }),
                    new KeyEvent(ConsoleKey.Escape, () => { escape = true; }),
                    new KeyEvent(ConsoleKey.LeftArrow, () => { MainFormHolder.HeldForm.movePrevious(); }),
                    new KeyEvent(ConsoleKey.RightArrow, () => { MainFormHolder.HeldForm.moveNext(); }),
                    new KeyEvent((char a) => { if (Char.IsLetter(a)) { guessForm.pushChar(a); hasEntered = false; } }, true) });

                guessForm.SelectedColor = ConsoleColor.DarkYellow;
                MainFormHolder.HeldForm = guessForm;

                int n = questions.Count;
                int score = 0;

                while (n > 0)
                {
                    int attempts = 3;
                    int k = rng.Next(n--);

                    //Shuffle and display list elements
                    //Displays as it shuffles
                    var temp = questions[k];
                    questions[k] = questions[n];
                    questions[n] = temp;
                    questions[n].ClearBlank();
                    questions[n].CorrectAnswers = 0;
                  
                    questionField.ContentText = questions[n].Qst;
                    questionField.X = ConsoleManipulator.center(Console.WindowWidth, questionField.ContentText.Length);
                    blankField.ContentText = new string(questions[n].Blank);
                    blankField.X = ConsoleManipulator.center(Console.WindowWidth, blankField.ContentText.Length);
                    errorField.ContentText = "You have " + attempts + " Attempts Remaining";
                    errorField.BackgroundColor = errorField.ParentForm.BackgroundColor;
                    errorField.X = ConsoleManipulator.center(Console.WindowWidth, errorField.ContentText.Length);

                    MainFormHolder.HeldForm.Refresh();

                    while (attempts > 0 && questions[n].isCompleted() == false)
                    {
                        MainFormHolder.HeldForm.AwaitKey();
                        if (hasEntered && answerField.Input != null && answerField.Input != String.Empty)
                        {
                            if (!questions[n].checkExists(answerField.Input[0]))
                            {
                                --attempts;
                                errorField.ContentText = "You have " + attempts + " Attempts Remaining";
                                if (attempts == 2)
                                    errorField.BackgroundColor = ConsoleColor.DarkYellow;
                                else if (attempts == 1)
                                    errorField.BackgroundColor = ConsoleColor.DarkRed;
                            }
                            answerField.Input = "";
                            hasEntered = false;
                        }

                        if (escape) { break; }

                        blankField.ContentText = new string(questions[n].Blank);
                        blankField.X = ConsoleManipulator.center(Console.WindowWidth, blankField.ContentText.Length);
                        answerField.X = ConsoleManipulator.center(Console.WindowWidth, answerField.ContentText.Length);

                        if (questions[n].isCompleted())
                        {
                            score++;
                            errorField.ContentText = "Correct! Press Any Key to Proceed!";
                            errorField.BackgroundColor = ConsoleColor.DarkGreen;
                            errorField.X = ConsoleManipulator.center(Console.WindowWidth, errorField.ContentText.Length);
                            MainFormHolder.HeldForm.Refresh();
                            Console.ReadKey(true);
                            break;
                        }

                        MainFormHolder.HeldForm.Refresh();
                    }

                    if (escape == true)
                    {
                        break;
                    }

                    if (!questions[n].isCompleted())
                    {
                        errorField.ContentText = "Wrong Answer! You've used up all your attempts.";
                        errorField.BackgroundColor = ConsoleColor.DarkRed;
                        errorField.X = ConsoleManipulator.center(Console.WindowWidth, errorField.ContentText.Length);
                        MainFormHolder.HeldForm.Refresh();
                        Console.ReadKey(true);
                    }
                }

                if (!escape)
                {
                    if (score > 0)
                    {
                        errorField.BackgroundColor = ConsoleColor.DarkGreen;
                        errorField.ContentText = "Congratulations! You got " + score + " out of " + questions.Count + " correct answers. Splendid Job!";
                    }
                    else
                    {
                        errorField.BackgroundColor = ConsoleColor.DarkRed;
                        errorField.ContentText = "You got " + score + " out of " + questions.Count + " correct answers. Better luck next time!";
                    }

                    errorField.X = ConsoleManipulator.center(Console.WindowWidth, errorField.ContentText.Length);

                    answerField.isEnabled = false;

                    MainFormHolder.HeldForm.RemoveElement(MainFormHolder.HeldForm.Elements.Find(r => (r as ElementText).ContentText == "Press Escape to return to Main Menu"));

                    ElementSelectable tryAgain_Yes = new ElementSelectable("Yes", 4, 18);
                    tryAgain_Yes.SelectedReturn = 1;

                    ElementSelectable tryAgain_No = new ElementSelectable("No", 70, 18);
                    tryAgain_No.SelectedReturn = 2;

                    MainFormHolder.HeldForm.AddElement(new Element[] { tryAgain_Yes, tryAgain_No });
                    MainFormHolder.HeldForm.AddElement(new ElementText("Try Again?", ConsoleManipulator.center(Console.WindowWidth, "Try Again?".Length), 18 ));
                    MainFormHolder.HeldForm.moveNext();

                    int selected = 0;

                    guessForm.FormKeyHandler.Register(new KeyEvent(ConsoleKey.Enter, () => { selected = (MainFormHolder.HeldForm.SelectedElement as ElementSelectable).SelectedReturn; }));

                    while (selected == 0)
                    {
                        MainFormHolder.HeldForm.Refresh();
                        MainFormHolder.HeldForm.AwaitKey();
                    }

                    again = selected == 1;
                }
                else
                {
                    again = false;
                }

            }

            MainFormHolder.HeldForm = MainForm;
            Console.Clear();

        }


        public static void stringConversion()
        {
            var STCForm = new CForm(100, 11){ BackgroundColor = ConsoleColor.DarkCyan, SelectedColor = ConsoleColor.DarkYellow, };
            MainFormHolder.HeldForm = STCForm;

            //Input
            ElementInput InputField = new ElementInput{ Y = 7, MaxInputLength = 82, };
            InputField.X = ConsoleManipulator.center(Console.WindowWidth, InputField.ContentText.Length);

            //Result
            ElementText ErrorField = new ElementText { ContentText = " ", Y = 5, };
            ErrorField.X = ConsoleManipulator.center(Console.WindowWidth, ErrorField.ContentText.Length);

            STCForm.AddElement(new ElementText("String Conversion Program", ConsoleManipulator.center(Console.WindowWidth, "String Conversion Program".Length), 1));
            STCForm.AddElement(new ElementText("Input a string and I will convert the alternating characters into their inverse cases.", ConsoleManipulator.center(Console.WindowWidth, "Input a string and I will convert the alternating characters into their inverse cases.".Length), 2));
            STCForm.AddElement(new ElementText("Press the ESC Key to return to the Main Menu", ConsoleManipulator.center(Console.WindowWidth, "Press the ESC Key to return to the Main Menu".Length), 9));
            STCForm.AddElement(new Element[] { InputField, ErrorField});

            bool escape = false;
            bool hasInput = false;
            STCForm.FormKeyHandler.Register(new KeyEvent[] { new KeyEvent((char a) => { if (MainFormHolder.HeldForm.pushChar(a)) hasInput = true; }, true) ,
                new KeyEvent(ConsoleKey.Backspace, () => { MainFormHolder.HeldForm.popChar(); hasInput = true; }),
                new KeyEvent(ConsoleKey.Escape, () => { escape = true; }) });

            ErrorField.BackgroundColor = ConsoleColor.DarkRed;
            MainFormHolder.HeldForm.Refresh();

            while (escape == false)
            {
                hasInput = false;
                MainFormHolder.HeldForm.AwaitKey();

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

                MainFormHolder.HeldForm.Refresh();
            }

            MainFormHolder.HeldForm.Refresh();
            MainFormHolder.HeldForm = MainForm;
            Console.Clear();

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

            MainForm.FormKeyHandler.Register(new KeyEvent[] { new KeyEvent(ConsoleKey.DownArrow, () => { MainFormHolder.HeldForm.moveNext(); }),
                new KeyEvent(ConsoleKey.UpArrow, () => { MainFormHolder.HeldForm.movePrevious(); }),
                new KeyEvent(ConsoleKey.Enter, () => { if (MainFormHolder.HeldForm.SelectedElement.ElementType != "Input") { ExerciseManager.Pass(MainFormHolder.HeldForm.SelectedIndex); }; }),
                new KeyEvent((char a) => { MainForm.pushChar(a); } , true),
                new KeyEvent(ConsoleKey.Backspace, () => { MainForm.popChar(); }),
                new KeyEvent(ConsoleKey.Delete, () => { MainForm.RemoveElement(Input_Element); })});

            MainFormHolder.HeldForm = MainForm;
            MainFormHolder.HeldForm.Refresh();
            
            while (true)
            {               
                MainFormHolder.HeldForm.AwaitKey();
                MainFormHolder.HeldForm.Refresh();
                
            }
            
        }
    }
}
