using Crud.BackEnd.Domain.Core.Messages;
using Crud.BackEnd.Domain.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace Crud.BackEnd.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
