using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public class SpecialCharacterValidator : BasePasswordValidator
    {
        protected override string GetValidatorName()
        {
            return "SpecialCharacterValidator";
        }

        protected override bool IsValid(string password)
        {
            return password.Any(c => !char.IsLetterOrDigit(c));
        }
    }
}
