using System;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    public class RelayCommand<T>
        : ICommand
        where T : class
    {
        private readonly Action<T> excute;
        private readonly Func<T, bool> canExcute;

        public RelayCommand(Action<T> excute, Func<T, bool> canExcute = null)
        {
            this.excute = excute;
            this.canExcute = canExcute;
        }

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public bool CanExecute(object parameter)
        => canExcute == null || canExcute((T)parameter);

        public void Execute(object parameter)
        => excute((T)parameter);
    }
}