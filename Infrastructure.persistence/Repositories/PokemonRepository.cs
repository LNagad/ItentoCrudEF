using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.persistence.Contexts;

namespace Infrastructure.persistence.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<object> GetAllWithInclude()
        {
            var pokemons = _dbContext.Pokemons.Select(c => new
            {
                c.Id,
                c.Name,
                c.PhotoUrl,
                c.PrimaryTypeId, 
                c.RegionId,
                FromRegion = new { c.Region.Name },
                PrimaryType = new { c.PrimaryType.Name },
                SecondaryType = c.SecondaryType != null ? new { c.SecondaryType.Name } : null
            }).ToList();

            return pokemons;
        }
    }
}
