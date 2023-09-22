using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
        IEnumerable<object> GetAllWithInclude();
    }
}