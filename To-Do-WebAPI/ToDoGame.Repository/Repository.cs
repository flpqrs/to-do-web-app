using Microsoft.EntityFrameworkCore;
using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Entities;
using ToDoGame.Domain.Interfaces.Repositories;

namespace ToDoGame.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _dbContext;

        protected DbSet<T> Table => _dbContext.Set<T>();

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await Table.FirstAsync(entity => entity.Id == id, cancellationToken);

            Table.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
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
        public virtual async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<UserProfile> GetUserProfileAsync(string userId, CancellationToken cancellationToken)
        {

            return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);

        }
    }
}
