using Crud.BackEnd.Application.Commands;

namespace Crud.BackEnd.Application.Validation
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }

}
