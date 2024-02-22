using password.Models;
using password.Stores;
using password.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
        public void SetParameter(string key, object value)
        {
            _navigationStore.SetParameter(key, value);
        }
        public object GetParameter(string key)
        {
            return _navigationStore.GetParameter(key);
        }
    }
}
