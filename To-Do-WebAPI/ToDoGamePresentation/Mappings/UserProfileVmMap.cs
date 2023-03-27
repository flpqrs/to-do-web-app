using AutoMapper;
using ToDoGame.Service.DTO;
using ToDoGamePresentation.Models;

namespace ToDoGamePresentation.Mappings
{
    public class UserProfileVmMap : Profile
    {
        public UserProfileVmMap()
        {
            CreateMap<UserProfileDto, UserProfileViewModel>().ReverseMap();
        }
    }
}
