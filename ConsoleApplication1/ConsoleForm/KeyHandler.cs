using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class KeyHandler
    {
        private List<KeyEvent> KeyEvents = new List<KeyEvent>();

        public void Register(KeyEvent keyEvent) //Registers a key. If a key is registered more than once, the latest passed delegate will be assigned to it.
        {
            if(keyEvent.isChar == false)
            {
                KeyEvent testCon;
                try
                {
                    testCon = KeyEvents.First(r => r.KeyInfo.ToString() == keyEvent.KeyInfo.ToString());
                }
                catch
                {
                    testCon = null;
                }
                
                if (testCon == null)
                {
                    KeyEvents.Add(keyEvent);
                }
                else
                {
                    testCon.Run = keyEvent.Run;
                }
            }else
            {
                KeyEvents.Add(keyEvent);
            }
        }

        public void Register(IEnumerable<KeyEvent> events)
        {
            foreach(KeyEvent ke in events)
            {
                Register(ke);
            }   
        }

        public void PassKey(ConsoleKeyInfo keyInfo)
        {
            KeyEvent testCon;

            //Weird way of using try clauses **Sorry
            try
            {
                testCon = KeyEvents.First(r => r.KeyInfo.ToString() == keyInfo.Key.ToString());
            }
            catch
            {
                testCon = null;
                try
                {
                    testCon = KeyEvents.First(r => r.isChar == true);
                }
                catch
                {
                    testCon = null;
                }
            }

            if (testCon != null)
            {
                if (testCon.isChar)
                {
                    testCon.RunChar(keyInfo.KeyChar);
                }
                else
                {
                    testCon.Run();
                }
                
            }
        }

    }
}
