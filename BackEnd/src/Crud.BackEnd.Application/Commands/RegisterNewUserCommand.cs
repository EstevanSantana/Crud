using Crud.BackEnd.Application.Validation;
using System;

namespace Crud.BackEnd.Application.Commands
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string fistName, string lastName, string email, DateTime birthday, int schooling)
        {
            FistName = fistName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Schooling = schooling;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
