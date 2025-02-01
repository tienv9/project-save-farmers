using AutoMapper;
using FarmerAPI.Domain.Contracts;
using FarmerAPI.Domain.Entities;

namespace FarmerAPI.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserResponse>();
            CreateMap<ApplicationUser, CurrentUserResponse>();
            CreateMap<UserRegisterRequest, ApplicationUser>();
        }
    }
}
