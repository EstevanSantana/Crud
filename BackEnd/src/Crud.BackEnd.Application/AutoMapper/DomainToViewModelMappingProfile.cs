using AutoMapper;
using Crud.BackEnd.Application.ViewModel;
using Crud.BackEnd.Domain.Models;

namespace Crud.BackEnd.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
