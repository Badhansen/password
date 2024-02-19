using password.Stores;
using password.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using password.ViewModels;
using password.Services;
using System.Windows;

namespace password
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateRegistrationViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private RegistrationViewModel CreateRegistrationViewModel()
        {
            return new RegistrationViewModel(new NavigationService(_navigationStore, CreateSuccessViewModel));
        }
        private SuccessViewModel CreateSuccessViewModel()
        {
            return new SuccessViewModel(new NavigationService(_navigationStore, CreateRegistrationViewModel));
        }
    }
}
