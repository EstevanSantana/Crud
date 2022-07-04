using Crud.BackEnd.Application.Commands;

namespace Crud.BackEnd.Application.Validation
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateFistName();
            ValidateLastName();
            ValidateBirthday();
            ValidateSchooling();
        }
    }

}
