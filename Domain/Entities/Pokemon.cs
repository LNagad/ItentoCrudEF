using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Pokemon : AuditableBaseEntity
    {
        public required string Name { get; set; }

        public required string PhotoUrl { get; set; }

        public required int PrimaryTypeId { get; set; }
        public required int RegionId { get; set; }
        public int? SecondaryTypeId { get; set; }

        public PokemonType? PrimaryType { get; set; }
        public PokemonType? SecondaryType { get; set; }

        public Region? Region { get; set; }
    }
}
