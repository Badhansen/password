using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public class UpperCaseValidator : BasePasswordValidator
    {
        protected override bool IsValid(string password)
        {
            return password.Any(char.IsUpper);
        }
        protected override string GetValidatorName()
        {
            return "UpperCaseValidator";
        }
    }
}
