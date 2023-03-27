using AutoMapper;
using ToDoGame.Service.DTO;
using ToDoGamePresentation.Models;

namespace ToDoGamePresentation.Mappings
{
    public class MissionVmMap : Profile
    {
        public MissionVmMap()
        {
            CreateMap<MissionDto, MissionViewModel>().ReverseMap();
        }
    }
}