using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Entities;

namespace ToDoGame.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken);

        IEnumerable<TEntity> GetAll();

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task SaveChanges(CancellationToken cancellationToken);
        Task<UserProfile> GetUserProfileAsync(string userId, CancellationToken cancellationToken);

    }
}