using AutoMapper;
using TenderplanTestTask.Dtos;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Profiles
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<UserCreateDto, User>();
        }
    }
}