using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public class LowerCaseValidator : BasePasswordValidator
    {
        protected override string GetValidatorName()
        {
            return "LowerCaseValidator";
        }

        protected override bool IsValid(string password)
        {
            return password.Any(char.IsLower);
        }
    }
}
