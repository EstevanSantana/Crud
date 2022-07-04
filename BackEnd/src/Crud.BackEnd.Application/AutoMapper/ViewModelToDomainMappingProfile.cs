using AutoMapper;
using Crud.BackEnd.Application.ViewModel;
using Crud.BackEnd.Domain.Models;

namespace Crud.BackEnd.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>();
        }
    }
}
