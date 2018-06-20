using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class KeyEvent
    {
        public KeyEvent(ConsoleKey pkey, Action to_run)
        {
            KeyInfo = pkey;
            Run = to_run;
        }

        public KeyEvent(Action<char> to_run, bool character)
        {
            RunChar = to_run;
            isChar = character;
            KeyInfo = null;
        }

        public ConsoleKey? KeyInfo { get; set; }
        public Action Run;
        public Action<char> RunChar;
        public bool isChar { get; set; }
    }
}
