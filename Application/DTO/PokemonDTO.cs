namespace Core.Application.DTO
{
    public class PokemonDTO
    {
        public required string Name { get; set; }

        public required string PhotoUrl { get; set; }

        public required int PrimaryTypeId { get; set; }
        public required int RegionId { get; set; }
        public int? SecondaryTypeId { get; set; }
    }
}
