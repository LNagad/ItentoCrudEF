using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.Services;
using Core.Domain.Entities;

namespace Core.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IGenericRepository<Region> _repository;

        public RegionService(IGenericRepository<Region> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Region> GetAllAsyncEnumerable()
        {
            var pokemons = _repository.GetAllAsyncEnumerable();

            return pokemons;
        }

        public async Task<Region?> GetByIdAsync(int id)
        {
            var pokemon = await _repository.GetByIdAsync(id);

            return pokemon;
        }


        public async Task<Region?> AddAsync(string name)
        {
            if (name.Length > 50)
            {
                return null;
            }

            var entityAdded = new Region { Name = name };

            await _repository.AddAsync(entityAdded);

            return entityAdded;
        }

        public virtual async Task<bool> UpdateAsync(string name, int id)
        {
            var entityUpdated = new Region { Name = name };

            return await _repository.UpdateAsync(entityUpdated, id);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
