using Crud.BackEnd.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.BackEnd.Application.Queries
{
    public interface IUserQueries
    {
        Task<UserViewModel> GetUserById(Guid id);
        Task<UserViewModel> GetUserByEmail(string email);
        Task<IEnumerable<UserViewModel>> GetAll();
    }
}
