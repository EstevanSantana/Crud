using Crud.BackEnd.Domain.Core.Data;
using Crud.BackEnd.Domain.Interfaces;
using Crud.BackEnd.Domain.Models;
using Crud.BackEnd.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.BackEnd.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(User user) 
        => _context.Users.Add(user); 

        public async Task<IEnumerable<User>> GetAll()
        => await _context.Users.AsNoTracking().ToListAsync();

        public async Task<User> GetUserByEmail(string email)
        => await _context.Users.Where(x => x.Email == email).AsNoTracking().FirstOrDefaultAsync();

        public async Task<User> GetUserById(Guid id)
        => await _context.Users.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

        public void Remove(User user)
        => _context.Users.Remove(user);

        public void Update(User user)
        => _context.Users.Update(user);

        public void Dispose()
        => _context?.Dispose();
    }
}
