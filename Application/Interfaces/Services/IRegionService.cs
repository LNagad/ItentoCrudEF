using Core.Domain.Entities;

namespace Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<Region?> AddAsync(string name);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Region> GetAllAsyncEnumerable();
        Task<Region?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(string name, int id);
    }
}