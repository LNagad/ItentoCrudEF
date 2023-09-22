using Core.Domain.Common;

namespace Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : AuditableBaseEntity
    {
        Task<Entity> AddAsync(Entity entity);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Entity> GetAllAsyncEnumerable();
        Task<Entity?> GetByIdAsync(int id);
        IQueryable<Entity> GetQueryable();
        Task<bool> UpdateAsync(Entity entity, int id);
        Task<int> SaveChangesAsync();
    }
}