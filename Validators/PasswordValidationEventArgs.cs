using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public class PasswordValidationEventArgs : EventArgs
    {
        public string Password { get; }
        public bool IsValid { get; }
        public string ValidatorName { get; } // Add this property
        public PasswordValidationEventArgs(string password, bool isValid, string validatorName)
        {
            Password = password;
            IsValid = isValid;
            ValidatorName = validatorName;
        }
    }
}
