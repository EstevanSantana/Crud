﻿using Crud.BackEnd.Domain.Core.Messages;
using Crud.BackEnd.Domain.Enum;
using System;

namespace Crud.BackEnd.Application.Events
{
    public class RegisterUserEvent : Event
    {
        public Guid Id { get; set; }
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        public TypeSchooling Schooling { get; private set; }

        public RegisterUserEvent(Guid id, string fistName, string lastName, string email, DateTime birthday, TypeSchooling schooling)
        {
            AggregateId = id;
            Id = id;
            FistName = fistName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Schooling = schooling;
        }
    }
}
