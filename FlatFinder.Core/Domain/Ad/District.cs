namespace FlatFinder.Core.Domain.Ad
{
    public class District: BaseEntity
    {
        public string Name { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}
