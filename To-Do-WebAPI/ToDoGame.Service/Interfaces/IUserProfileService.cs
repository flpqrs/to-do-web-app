using ToDoGame.Service.DTO;

namespace ToDoGame.Service.Interfaces
{
    public interface IUserProfileService
    {
        Task<Guid> CreateAsync(UserProfileDto personDto, CancellationToken cancellationToken);

        Task<IEnumerable<UserProfileDto>> GetAllAsync(CancellationToken cancellationToken);

        Task<UserProfileDto> GetAsync(Guid id, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task UpdateAsync(UserProfileDto personDto, CancellationToken cancellationToken);

        Task<UserProfileDto> GetUserProfileAsync(string userId, CancellationToken cancellationToken);

    }
}
