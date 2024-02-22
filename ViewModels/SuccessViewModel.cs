using NavigationService = password.Services.NavigationService;

namespace password.ViewModels
{
    public class SuccessViewModel : ViewModelBase
    {
        private NavigationService _navigationService;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public void LoadData()
        {
            var parameter = _navigationService.GetParameter("Name");
            Name = (string)parameter;
        }

        public SuccessViewModel(NavigationService registrationNavigationService)
        {
            _navigationService = registrationNavigationService;
            LoadData();
        }
    }
}
