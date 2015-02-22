namespace FlatFinder.Core.Domain.Ad
{
    public class Address : BaseEntitySoftDelete
    {
        public string Street { get; set; }
        public decimal House { get; set; }
        public decimal Flat { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual District District{ get; set; }
    }
}