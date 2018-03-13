using System;
using System.Windows.Input;

namespace ERTranslator
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public Action<object> MyAction;

        public void Execute(object parameter)
        {
            MyAction(parameter);
        }
    }
}
