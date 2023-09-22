using Core.Application.DTO;
using Core.Domain.Entities;

namespace Core.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<Pokemon?> AddAsync(PokemonDTO pokemonDTO);
        Task<bool> DeleteAsync(int id);
        IEnumerable<object> GetAllAsyncEnumerable();
        Task<Pokemon?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(PokemonDTO pokemonDTO, int id);
    }
}