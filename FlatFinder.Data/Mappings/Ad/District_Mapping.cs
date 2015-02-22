using FlatFinder.Core.Domain.Ad;
using System.Data.Entity.ModelConfiguration;
namespace FlatFinder.Data.Mappings.Ad
{
    internal class District_Mapping: EntityTypeConfiguration<District>
    {
        public District_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("District");

            Property(t => t.Id).HasColumnName("DistrictId");

            Property(t => t.Name).HasMaxLength(50);
        }
    }
}
