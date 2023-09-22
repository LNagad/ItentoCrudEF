using Core.Domain.Entities;

namespace Core.Application.Interfaces.Services
{
    public interface IPokemonTypeService
    {
        Task<PokemonType?> AddAsync(string name);
        Task<bool> DeleteAsync(int id);
        IEnumerable<PokemonType> GetAllAsyncEnumerable();
        Task<PokemonType?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(string name, int id);
    }
}