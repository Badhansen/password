using password.Commands;
using password.Services;
using password.Validators;
using System.Windows.Input;

namespace password.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public BasePasswordValidator validator;
        public bool validationCheckingStatus = false;
        private NavigationService _navigationService;

        private string _fristName;
        public string FirstName
        {
            get => _fristName;
            set
            {
                _fristName = value;
                OnPropertyChanged(nameof(FirstName));
                _navigationService.SetParameter("Name", value);
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
                validationCheckingStatus = validator.Validate(Password);
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

        private static readonly string _accepted = "pack://application:,,,/Assets/Accepted.png";
        private static readonly string _rejected = "pack://application:,,,/Assets/Rejected.png";
        
        private string _lengthMark;
        public string LengthMark
        {
            get => _lengthMark;
            set
            {
                _lengthMark = value;
                OnPropertyChanged(nameof(LengthMark));
            }
        }
        private string _upperCaseMark;
        public string UpperCaseMark
        {
            get => _upperCaseMark;
            set
            {
                _upperCaseMark = value;
                OnPropertyChanged(nameof(UpperCaseMark));
            }
        }
        private string _lowerCaseMark;
        public string LowerCaseMark
        {
            get => _lowerCaseMark;
            set
            {
                _lowerCaseMark = value;
                OnPropertyChanged(nameof(LowerCaseMark));
            }
        }
        private string _specialCharacterMark;
        public string SpecialCharacterMark
        {
            get => _specialCharacterMark;
            set
            {
                _specialCharacterMark = value;
                OnPropertyChanged(nameof(SpecialCharacterMark));
            }
        }
        public ICommand RegisterCommand { get; }
        public RegistrationViewModel(NavigationService reservationViewNavigationService) 
        {
            _navigationService = reservationViewNavigationService;
            RegisterCommand = new RegistrationCommand(this, reservationViewNavigationService);
            validator = new LengthValidator(8);
            var upperCaseValidator = new UpperCaseValidator();
            var lowerCaseValidator = new LowerCaseValidator();
            var specialCaseValidator = new SpecialCharacterValidator();
            validator.SetNextValidator(upperCaseValidator)
                .SetNextValidator(lowerCaseValidator)
                .SetNextValidator(specialCaseValidator);

            validator.ValidationEvent += OnValidationUpdate;
            upperCaseValidator.ValidationEvent += OnValidationUpdate;
            lowerCaseValidator.ValidationEvent += OnValidationUpdate;
            specialCaseValidator.ValidationEvent += OnValidationUpdate;

            LengthMark = _rejected;
            UpperCaseMark = _rejected;
            LowerCaseMark = _rejected;
            SpecialCharacterMark = _rejected;
        }

        private void OnValidationUpdate(object? sender, PasswordValidationEventArgs e)
        {
            if (e.ValidatorName == "LengthValidator")
            {
                if (e.IsValid)
                {
                    LengthMark = _accepted;
                }
                else
                {
                    LengthMark = _rejected;
                }
            }
            if (e.ValidatorName == "UpperCaseValidator")
            {
                if (e.IsValid)
                {
                    UpperCaseMark = _accepted;
                }
                else
                {
                    UpperCaseMark = _rejected;
                }
            }
            if (e.ValidatorName == "LowerCaseValidator")
            {
                if (e.IsValid)
                {
                    LowerCaseMark = _accepted;
                }
                else
                {
                    LowerCaseMark = _rejected;
                }
            }
            if (e.ValidatorName == "SpecialCharacterValidator")
            {
                if (e.IsValid)
                {
                    SpecialCharacterMark = _accepted;
                }
                else
                {
                    SpecialCharacterMark = _rejected;
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
