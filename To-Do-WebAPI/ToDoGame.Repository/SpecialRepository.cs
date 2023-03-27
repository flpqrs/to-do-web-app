using Microsoft.EntityFrameworkCore;
using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Entities;
using ToDoGame.Domain.Interfaces.Repositories;

namespace ToDoGame.Repository
{
    public class SpecialRepository<T> : ISpecialRepository<T> where T : class, IIntIdEntity
    {
        private readonly ApplicationDbContext _dbContext;

        protected DbSet<T> Table => _dbContext.Set<T>();

        public SpecialRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await Table.FirstAsync(entity => entity.Id == id, cancellationToken);

            Table.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T?> GetAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await Table.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table;
        }

        public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken)
        {
            Table.Add(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            Table.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Level> GetCurrentLevelAsync(UserProfile user, CancellationToken cancellationToken)
        {
            var currentUserProfileLevel = _dbContext.Levels.FirstAsync(l => 
            l.ExperienceRangeFrom <= user.ExperiencePoints
            && user.ExperiencePoints <= l.ExperienceRangeTo,
            cancellationToken);

            return await currentUserProfileLevel;
        }

        public virtual async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
