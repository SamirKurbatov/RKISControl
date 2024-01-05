using RKISControl.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RKISControl.Commands
{
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<Task> execute;

        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public RelayCommandAsync(Func<Task> execute, Func<object, bool> canExecute = default)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteAsync(parameter).ConfigureAwait(false);
        }

        public async Task ExecuteAsync(object parameter)
        {
            await execute?.Invoke();
        }
    }
}
