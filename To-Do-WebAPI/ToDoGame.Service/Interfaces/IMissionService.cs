using ToDoGame.Service.DTO;

namespace ToDoGame.Service.Interfaces
{
    public interface IMissionService
    {
        Task<Guid> CreateAsync(MissionDto missionDto, CancellationToken cancellationToken);

        Task<MissionDto> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<MissionDto>> GetAllByUserProfileIdAsync(Guid userId, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task UpdateAsync(MissionDto missionDto, CancellationToken cancellationToken);

    }
}
