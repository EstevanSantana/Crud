using Crud.BackEnd.Application.Commands;

namespace Crud.BackEnd.Application.Validation
{
    public class RegisterNewUserCommandValidation : UserValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            ValidateEmail();
            ValidateFistName();
            ValidateLastName();
            ValidateBirthday();
            ValidateSchooling();
        }
    }

}
