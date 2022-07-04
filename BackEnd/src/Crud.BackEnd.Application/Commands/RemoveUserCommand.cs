using Crud.BackEnd.Application.Validation;
using System;

namespace Crud.BackEnd.Application.Commands
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
