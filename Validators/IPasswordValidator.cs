using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password.Validators
{
    public interface IPasswordValidator
    {
        bool Validate(string password);
        IPasswordValidator SetNextValidator(IPasswordValidator nextValidator);
    }
}
