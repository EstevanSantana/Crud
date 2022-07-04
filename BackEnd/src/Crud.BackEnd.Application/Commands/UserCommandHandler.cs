using Crud.BackEnd.Application.Events;
using Crud.BackEnd.Domain.Core.Mediator;
using Crud.BackEnd.Domain.Core.Messages;
using Crud.BackEnd.Domain.Core.Messages.Notifications;
using Crud.BackEnd.Domain.Enum;
using Crud.BackEnd.Domain.Interfaces;
using Crud.BackEnd.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crud.BackEnd.Application.Commands
{
    public class UserCommandHandler :
        IRequestHandler<RegisterNewUserCommand, bool>,
        IRequestHandler<RemoveUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public UserCommandHandler(IUserRepository userRepository, IMediatorHandler mediatorHandler)
        {
            _userRepository = userRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(RegisterNewUserCommand message, CancellationToken cancellationToken)
        {
            if (!CommandValid(message)) return false;

            var user = new User(Guid.NewGuid(), message.FistName, message.LastName, message.Email, message.Birthday, (TypeSchooling)message.Schooling);
            if (!await ShoolingValid(user))
            {
                return false;
            }

            if (await _userRepository.GetUserByEmail(message.Email) != null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("User", "O e-mail já foi cadastrado."));
                return false;
            }

            user.AddEvent(new RegisterUserEvent(user.Id, message.FistName, message.LastName, message.Email, message.Birthday, (TypeSchooling)message.Schooling));

            _userRepository.Add(user);
            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        {
            if (!CommandValid(message)) return false;

            var user = await _userRepository.GetUserById(message.Id);
            if (user == null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("User", "O user não existe"));
                return false;
            }

            user.AddEvent(new RemoveUserEvent(message.Id));

            _userRepository.Remove(user);

            return await _userRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            if (!CommandValid(message)) return false;

            var user = new User(message.Id, message.FistName, message.LastName, message.Email, message.Birthday, (TypeSchooling)message.Schooling);
            if (!await ShoolingValid(user))
            {
                return false;
            }

            var existingUser = await _userRepository.GetUserById(message.Id);
            if (existingUser != null && existingUser.Id != message.Id)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("User", "O id não é valido."));
            }

            if (await _userRepository.GetUserByEmail(message.Email) == null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("User", "O e-mail não foi cadastrado."));
                return false;
            }

            user.AddEvent(new UpdateUserEvent(user.Id, message.FistName, message.LastName, message.Email, message.Birthday, (TypeSchooling)message.Schooling));

            _userRepository.Update(user);
            return await _userRepository.UnitOfWork.Commit();
        }

        private async Task<bool> ShoolingValid(User user)
        {
            if (!user.SchoolingValid())
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("User", "A escolaridade permite apenas os valores (Infantil, Fundamental, Médio e Superior)"));
                return false;
            }

            return true;
        }

        private bool CommandValid(Command message)
        {
            if (message.IsValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublishNotification(new DomainNotification("User", error.ErrorMessage));
            }

            return false;
        }
    }
}
