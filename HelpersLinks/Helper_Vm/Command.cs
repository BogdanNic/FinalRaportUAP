using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Helper_Vm
{
    public class Command : ICommand
    {
        private Action _action;
        private Action<object> _specialAction;
        private bool _canExecute;
        public Command(Action action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public Command(Action<object> action, bool canExecute = true)
        {
            _specialAction = action;
            _canExecute = canExecute;
        }
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    EventHandler canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
        public void Execute(object parameter)
        {
            _action();
        }
        public event EventHandler CanExecuteChanged;
    }
    public class Command<T> : ICommand
    {
        private Action _action;
        private Action<T> _specialAction;
        private bool _canExecute;

        public Command(Action<T> action, bool canExecute = true)
        {
            _specialAction = action;
            _canExecute = canExecute;
        }
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }
        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    EventHandler canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
        public void Execute(object parameter)
        {

            if (parameter != null && parameter is T)
            {
                T obj = (T)parameter;
                _specialAction(obj);
            }

        }
        public event EventHandler CanExecuteChanged;


    }
}
