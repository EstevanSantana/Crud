using AutoMapper;
using Crud.BackEnd.Application.ViewModel;
using Crud.BackEnd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.BackEnd.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserQueries(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.GetAll());
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetUserByEmail(email));
        }

        public async Task<UserViewModel> GetUserById(Guid id)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetUserById(id));
        }
    }
}
