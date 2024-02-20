using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public abstract class BasePasswordValidator : IPasswordValidator
    {
        public event EventHandler<PasswordValidationEventArgs> ValidationEvent;
        private IPasswordValidator _nextValidator;
        public bool Validate(string password)
        {
            bool isValid = IsValid(password);
            ValidationEvent?.Invoke(this, new PasswordValidationEventArgs(password, isValid, GetValidatorName()));
            return _nextValidator != null ? _nextValidator.Validate(password) : isValid;
        }
        public IPasswordValidator SetNextValidator(IPasswordValidator nextValidator)
        {
            _nextValidator = nextValidator;
            return nextValidator;
        }

        protected abstract bool IsValid(string password);
        protected abstract string GetValidatorName();
    }
}
