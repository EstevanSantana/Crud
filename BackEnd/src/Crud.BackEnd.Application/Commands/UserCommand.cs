using Crud.BackEnd.Domain.Core.Messages;
using Crud.BackEnd.Domain.Enum;
using System;

namespace Crud.BackEnd.Application.Commands
{
    public class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string FistName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public int Schooling { get; protected set; }
    }

}
