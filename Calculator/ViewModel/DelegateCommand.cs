using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.ViewModel
{
    class DelegateCommand : IDelegateCommand
    {
        private Action<object> _execute;

        public DelegateCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object param)
        {
            _execute(param);
        }
        public bool CanExecute(object param)
        {
            return true;
        }

    }
}