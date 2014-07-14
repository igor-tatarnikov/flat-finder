using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Data.Mappings.Ad
{
    internal class FlatInfo_Mapping: EntityTypeConfiguration<FlatInfo>
    {
        public FlatInfo_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("FlatInfo");

            Property(t => t.Id).HasColumnName("FlatInfoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(t => t.Address).WithMany().HasForeignKey(d => d.AddressId);
        }
    }
}
