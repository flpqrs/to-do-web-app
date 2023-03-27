using AutoMapper;
using ToDoGame.Domain.Entities;
using ToDoGame.Service.DTO;

namespace ToDoGame.Service.Mappings
{
    public class UserProfileDtoMap : Profile
    {
        public UserProfileDtoMap()
        {
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        }
    }
}
