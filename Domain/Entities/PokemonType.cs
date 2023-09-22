using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class PokemonType : AuditableBaseEntity
    {
        public required string Name { get; set; }

        public ICollection<Pokemon>? Pokemons { get; set; }
    }
}
