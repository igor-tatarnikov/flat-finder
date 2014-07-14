namespace FlatFinder.Core.Domain.Ad
{
    public class Address: BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public decimal House { get; set; }
        public decimal Flat { get; set; }
        public int? DistrictId { get; set; }

        public virtual District District{ get; set; }
    }
}