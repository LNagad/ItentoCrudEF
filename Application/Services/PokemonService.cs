using Core.Application.DTO;
using Core.Application.Interfaces.Repositories;
using Core.Application.Interfaces.Services;
using Core.Domain.Entities;

namespace Core.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;

        public PokemonService(IPokemonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<object> GetAllAsyncEnumerable()
        {
            var pokemons = _repository.GetAllWithInclude();

            return pokemons;
        }

        public async Task<Pokemon?> GetByIdAsync(int id)
        {
            var pokemon = await _repository.GetByIdAsync(id);

            return pokemon;
        }


        public async Task<Pokemon?> AddAsync(PokemonDTO pokemonDTO)
        {
            if (pokemonDTO.Name.Length > 50 || pokemonDTO.Name.Length <= 0) return null;
            if (pokemonDTO.PhotoUrl.Length <= 0) return null;
            if (pokemonDTO.PrimaryTypeId <= 0) return null;
            if (pokemonDTO.RegionId <= 0) return null;

            var entityAdded = new Pokemon
            {
                Name = pokemonDTO.Name,
                PhotoUrl = pokemonDTO.PhotoUrl,
                PrimaryTypeId = pokemonDTO.PrimaryTypeId,
                SecondaryTypeId = pokemonDTO.SecondaryTypeId <= 0 ? null : pokemonDTO.SecondaryTypeId,
                RegionId = pokemonDTO.RegionId,
            };

            await _repository.AddAsync(entityAdded);

            return entityAdded;
        }

        public virtual async Task<bool> UpdateAsync(PokemonDTO pokemonDTO, int id)
        {
            if (pokemonDTO.Name.Length > 50 || pokemonDTO.Name.Length <= 0) return false;
            if (pokemonDTO.PhotoUrl.Length <= 0) return false;
            if (pokemonDTO.PrimaryTypeId <= 0) return false;
            if (pokemonDTO.RegionId <= 0) return false;

            var entityUpdated = new Pokemon
            {
                Name = pokemonDTO.Name,
                PhotoUrl = pokemonDTO.PhotoUrl,
                PrimaryTypeId = pokemonDTO.PrimaryTypeId,
                SecondaryTypeId = pokemonDTO.SecondaryTypeId <= 0 ? null : pokemonDTO.SecondaryTypeId,
                RegionId = pokemonDTO.RegionId,
            };

            return await _repository.UpdateAsync(entityUpdated, id);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
