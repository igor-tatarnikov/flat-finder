using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Data.Mappings.Ad
{
    internal class FlatAd_Mapping : EntityTypeConfiguration<FlatAd>
    {
        public FlatAd_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("FlatAd");

            Property(t => t.Id).HasColumnName("FlatAdId");

            HasRequired(t => t.FlatInfo).WithMany().HasForeignKey(d => d.FlatInfoId);
            HasOptional(t => t.ContactInfo).WithMany().HasForeignKey(d => d.ContactInfoId);
        }
    }
}
