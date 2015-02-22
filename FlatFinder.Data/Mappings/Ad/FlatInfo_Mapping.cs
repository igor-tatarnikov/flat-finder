using FlatFinder.Core.Domain.Ad;
using System.Data.Entity.ModelConfiguration;
namespace FlatFinder.Data.Mappings.Ad
{
    internal class FlatInfo_Mapping: EntityTypeConfiguration<FlatInfo>
    {
        public FlatInfo_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("FlatInfo");

            Property(t => t.Id).HasColumnName("FlatInfoId");

            Property(t => t.Description).HasMaxLength(300);

            HasRequired(t => t.Address).WithMany().HasForeignKey(d => d.AddressId);
        }
    }
}
