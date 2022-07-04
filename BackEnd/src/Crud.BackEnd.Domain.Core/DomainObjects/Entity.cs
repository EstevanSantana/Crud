using Crud.BackEnd.Domain.Core.Messages;
using System;
using System.Collections.Generic;

namespace Crud.BackEnd.Domain.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public List<Event> _notification;
        public IReadOnlyCollection<Event> Notification => _notification?.AsReadOnly();

        public void AddEvent(Event @event)
        {
            _notification = _notification ?? new List<Event>();
            _notification.Add(@event);
        }

        public void RemoveEvent(Event @event)
        {
            _notification?.Remove(@event);
        }

        public void ClearEvent()
        {
            _notification?.Clear();
        }

        public virtual bool IsValido()
        {
            throw new NotImplementedException();
        }
    }
}
