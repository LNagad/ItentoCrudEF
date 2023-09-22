using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Region: AuditableBaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Pokemon>? Pokemons { get; set; }
    }
}
