using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public class LengthValidator : BasePasswordValidator
    {
        private readonly int _minLength;
        public LengthValidator(int minLength)
        {
            _minLength = minLength;
        }

        protected override string GetValidatorName()
        {
            return "LengthValidator";
        }

        protected override bool IsValid(string password)
        {
            return password.Length >= _minLength;
        }
    }
}
