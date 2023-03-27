using AutoMapper;
using ToDoGame.Domain.Entities;
using ToDoGame.Service.DTO;

namespace ToDoGame.Service.Mappings
{
    public class MissionDtoMap : Profile
    {
        public MissionDtoMap()
        {
            CreateMap<Mission, MissionDto>().ReverseMap();
        }
    }
}
