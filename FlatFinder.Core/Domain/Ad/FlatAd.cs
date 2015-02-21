using FlatFinder.Core.Domain.User;

namespace FlatFinder.Core.Domain.Ad
{
    public class FlatAd : BaseEntitySoftDelete
    {
        public int? FlatInfoId { get; set; }
        public int? ContactInfoId { get; set; }
        public decimal Price { get; set; }

        public virtual FlatInfo FlatInfo { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
    }
}
