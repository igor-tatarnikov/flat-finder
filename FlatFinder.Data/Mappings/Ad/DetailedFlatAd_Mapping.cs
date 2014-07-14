using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Data.Mappings.Ad
{
    internal class DetailedFlatAd_Mapping: EntityTypeConfiguration<DetailedFlatAd>
    {
        public DetailedFlatAd_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("DetailedFlatAd");

            Property(t => t.Id).HasColumnName("DetailedFlatAdId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(t => t.FlatInfo).WithMany().HasForeignKey(d => d.FlatInfoId);
            HasOptional(t => t.ContactInfo).WithMany().HasForeignKey(d => d.ContactInfoId);
        }
    }
}