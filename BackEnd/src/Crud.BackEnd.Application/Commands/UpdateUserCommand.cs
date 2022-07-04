using Crud.BackEnd.Application.Validation;
using System;

namespace Crud.BackEnd.Application.Commands
{
    public class UpdateUserCommand : UserCommand 
    {
        public UpdateUserCommand(Guid id, string fistName, string lastName, string email, DateTime birthday, int schooling)
        {
            Id = id;
            FistName = fistName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Schooling = schooling;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
