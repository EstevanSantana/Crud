using Crud.BackEnd.Domain.Core.DomainObjects;
using Crud.BackEnd.Domain.Enum;
using System;

namespace Crud.BackEnd.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthday { get; private set; }
        public TypeSchooling Schooling { get; private set; }

        public User(Guid id, string fistName, string lastName, string email, DateTime birthday, TypeSchooling schooling)
        {
            Id = id;
            FistName = fistName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Schooling = schooling;
        }

        protected User() { }

        public bool SchoolingValid()
        {
            var schooling = Schooling;
            switch (schooling)
            {
                case TypeSchooling.Children: return true;
                case TypeSchooling.Elementary: return true;
                case TypeSchooling.Higher: return true;
                case TypeSchooling.Middle: return true;

                default: 
                    break;
            }
            return false;
        }

    }
}
