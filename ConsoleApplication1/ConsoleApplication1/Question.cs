﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleManipulation;

namespace ConsoleApplication1
{
    public class Question
    {
        public Question(string inquiry, string ans)
        {
            CorrectAnswers = 0;
            Qst = inquiry;
            Answer = ans;
            Blank = new char[Answer.Length * 2];
            ClearBlank();
        }
        public int CorrectAnswers { private get; set; }
        public char[] Blank { get; set; }

        public string Qst { get; set; }
        public string Answer { get; private set; }

        public void Display()
        {
            ConsoleManipulator.centerPrint(Qst + "\n");
            ConsoleManipulator.centerPrint(new string(Blank) + "\n");
        }

        public void ClearBlank()
        {
            for (int i = 0; i < Blank.Length; i++)
            {
                if (i % 2 == 0)
                    Blank[i] = '_';
                else
                    Blank[i] = ' ';
            }
        }

        public bool checkExists(char a)
        {
            bool has_character = false;
            char testChar = Char.ToLower(a);
            for (int i = 0; i < Answer.Length; i++)
            {
                string lowerAnswer = Answer.ToLower();
                if (lowerAnswer[i] == testChar && testChar != Char.ToLower(Blank[i * 2]))
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
            if (CorrectAnswers == Answer.Length)
            {            
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}