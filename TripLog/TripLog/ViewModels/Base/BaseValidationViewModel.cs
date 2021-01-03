using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TripLog.ViewModels.Base
{
    public class BaseValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        readonly IDictionary<string, List<string>> _error = new Dictionary<string, List<string>>();
        public bool HasErrors => _error?.Any(x => x.Value?.Any() == true) == true;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return _error.SelectMany(x => x.Value);
            }
            if (_error.ContainsKey(propertyName) && _error[propertyName].Any() )
            {
                return _error[propertyName];
            }

            return new List<string>();
        }

        protected void Validation(Func<bool> rule, string error, [CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return;

            if (rule.Invoke() == false)
                _error.Add(propertyName, new List<string> { error });

            OnPropertyChanged(nameof(HasErrors));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
