using password.Commands;
using password.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace password.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string _fristName;
        public string FirstName
        {
            get => _fristName;
            set
            {
                _fristName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        public ICommand RegisterCommand { get; }
        public RegistrationViewModel(NavigationService reservationViewNavigationService) 
        {
            RegisterCommand = new RegistrationCommand(this, reservationViewNavigationService);
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
