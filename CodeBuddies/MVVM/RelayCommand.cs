using System.Reflection.Metadata;
using System.Windows.Input;

namespace CodeBuddies.MVVM
{
    public class RelayCommand<T> : ICommand
    {

        private Action<T> execute;
        private Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            execute((T)parameter);
        }
    }
}
