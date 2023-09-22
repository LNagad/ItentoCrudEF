using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.Services;
using Core.Domain.Entities;

namespace Core.Application.Services
{
    public class PokemonTypeService : IPokemonTypeService
    {
        private readonly IGenericRepository<PokemonType> _repository;

        public PokemonTypeService(IGenericRepository<PokemonType> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PokemonType> GetAllAsyncEnumerable()
        {
            var pokemonTypes = _repository.GetAllAsyncEnumerable();

            return pokemonTypes;
        }

        public async Task<PokemonType?> GetByIdAsync(int id)
        {
            var pokemonType = await _repository.GetByIdAsync(id);

            return pokemonType;
        }


        public async Task<PokemonType?> AddAsync(string name)
        {
            if (name.Length > 50)
            {
                return null;
            }

            var entityAdded = new PokemonType { Name = name };

            await _repository.AddAsync(entityAdded);

            return entityAdded;
        }

        public virtual async Task<bool> UpdateAsync(string name, int id)
        {
            var entityUpdated = new PokemonType { Name = name };

            return await _repository.UpdateAsync(entityUpdated, id);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
