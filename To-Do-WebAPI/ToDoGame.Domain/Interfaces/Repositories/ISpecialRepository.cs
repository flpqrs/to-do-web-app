using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Entities;

namespace ToDoGame.Domain.Interfaces.Repositories
{
    public interface ISpecialRepository<TEntity> where TEntity : IIntIdEntity
    {
        Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken);

        IEnumerable<TEntity> GetAll();

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);

        Task SaveChanges(CancellationToken cancellationToken);
        Task<Level> GetCurrentLevelAsync(UserProfile user, CancellationToken cancellationToken);

    }
}
