using Crud.BackEnd.Domain.Core.Messages;
using System;

namespace Crud.BackEnd.Application.Events
{
    public class RemoveUserEvent : Event
    {
        public Guid Id { get; set; }
        public RemoveUserEvent(Guid id)
        {
            AggregateId = id;
            Id = id;
        }
    }
}
