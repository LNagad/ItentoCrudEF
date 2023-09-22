using Core.Application.Interfaces.Repositories;
using Core.Domain.Common;
using Infrastructure.persistence.Contexts;

namespace Infrastructure.persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : AuditableBaseEntity
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<Entity> GetAllAsyncEnumerable()
        {
            return _dbContext.Set<Entity>().AsEnumerable();
        }

        public virtual async Task<Entity?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<Entity>(id);
        }

        public virtual IQueryable<Entity> GetQueryable()
        {
            return _dbContext.Set<Entity>();
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> UpdateAsync(Entity entity, int id)
        {
            var entityFounded = await _dbContext.FindAsync<Entity>(id);

            if (entityFounded == null) return false;

            entity.Id = entityFounded.Id;

            _dbContext.Entry(entityFounded).CurrentValues.SetValues(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entityFounded = await _dbContext.FindAsync<Entity>(id);

            if (entityFounded == null) return false;

            _dbContext.Remove(entityFounded);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}
