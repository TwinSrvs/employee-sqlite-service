using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assessment.ViewModels
{
    public class EmployeeBaseViewModel : INotifyPropertyChanged
    {
        #region EVENTS

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region METHODS

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;

            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}