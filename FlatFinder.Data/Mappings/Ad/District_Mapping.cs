using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;
namespace FlatFinder.Data.Mappings.Ad
{
    internal class District_Mapping: EntityTypeConfiguration<District>
    {
        public District_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("District");

            Property(t => t.Id).HasColumnName("FlatAdId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
