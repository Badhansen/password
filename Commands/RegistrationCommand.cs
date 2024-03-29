﻿using password.Services;
using password.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace password.Commands
{
    public class RegistrationCommand : CommandBase
    {
        private readonly RegistrationViewModel _registrationViewModel;
        private readonly NavigationService _registrationViewNavigationService;

        public RegistrationCommand(RegistrationViewModel registrationViewModel, NavigationService registrationViewNavigationService)
        {
            _registrationViewModel = registrationViewModel;
            _registrationViewNavigationService = registrationViewNavigationService;

            _registrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegistrationViewModel.ConfirmPassword))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _registrationViewModel.validationCheckingStatus
                && _registrationViewModel.Password.Equals(_registrationViewModel.ConfirmPassword)
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            try
            {
                _registrationViewNavigationService.Navigate();
            }
            catch (Exception)
            {
                MessageBox.Show("Registration Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
