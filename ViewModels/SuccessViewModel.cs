using password.Commands;
using password.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace password.ViewModels
{
    public class SuccessViewModel : ViewModelBase
    {
        public ICommand RegistrationCommand { get; }
        public SuccessViewModel(NavigationService registrationNavigationService)
        {
            RegistrationCommand = new NavigateCommand(registrationNavigationService);
        }
    }
}
