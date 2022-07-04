using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Crud.BackEnd.Application.Events
{
    public class UserEventHandler :
        INotificationHandler<RegisterUserEvent>,
        INotificationHandler<UpdateUserEvent>,
        INotificationHandler<RemoveUserEvent>

    {
        public Task Handle(RegisterUserEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdateUserEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RemoveUserEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
