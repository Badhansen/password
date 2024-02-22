using password.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Stores
{
    public class NavigationStore
    {
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public void SetParameter(string key, object value)
        {
            _parameters[key] = value;
        }
        public object GetParameter(string key)
        {
            return _parameters.ContainsKey(key) ? _parameters[key] : null;
        }
    }
}
