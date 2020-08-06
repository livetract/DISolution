using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool Set<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            // 如果value没有变化
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            // 如果确实是一个新的值
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
