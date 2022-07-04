using Crud.BackEnd.Domain.Core.Mediator;
using Crud.BackEnd.Domain.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Crud.BackEnd.API.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHeadler;

        public ApiController(INotificationHandler<DomainNotification> notifications,
                             IMediatorHandler mediatorHeadler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHeadler = mediatorHeadler;
        }
        protected ActionResult CustomResponse(object result = null)
        {
            if (!IsOperationValid())
            {
                return BadRequest(new
                {
                    success = false,
                    error = _notifications.GetNotifications().Select(x => x.Value)
                });
            }

            return Ok(new { success = true, data = result });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) GetNotificationError(modelState);
            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            return !_notifications.IsNotification();
        }

        protected void GetNotificationError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                NotificationError(erro.ErrorMessage, erro.Exception.Message);
            }
        }

        protected void NotificationError(string code, string message)
        {
            _mediatorHeadler.PublishNotification(new DomainNotification(code, message));
        }
    }
}
