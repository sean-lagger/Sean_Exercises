using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForm
{
    public class FormHolder
    {
        private CForm _currentForm;

        public FormHolder()
        {
            HasSwitched = false;
        }

        public FormHolder(CForm c)
        {
            HasSwitched = false;
            _currentForm = c;
        }
        
        public bool HasSwitched { get; set; }
        public CForm HeldForm
        {
            get { return _currentForm; }
            set
            {
                if(_currentForm != null)
                   _currentForm.Holder = null;

                HasSwitched = true;
                _currentForm = value;
                _currentForm.Holder = this;
            }
        }
    }
}
