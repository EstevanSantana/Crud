using Crud.BackEnd.Domain.Core.Data;
using Crud.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.BackEnd.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Add(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        void Update(User user);
        void Remove(User user);
    }
}
