namespace FlatFinder.Core.Domain.Ad
{
    public class FlatInfo : BaseEntitySoftDelete
    {
        public string Description { get; set; }
        public int? AddressId { get; set; }
        public int Floor { get; set; }
        public int RoomsCount { get; set; }

        public virtual Address Address { get; set; }
    }
}
