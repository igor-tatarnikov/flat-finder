using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;
namespace FlatFinder.Data.Mappings.Ad
{
    internal class Address_Mapping: EntityTypeConfiguration<Address>
    {
        public Address_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("Address");

            Property(t => t.Id).HasColumnName("AddressId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(t => t.District).WithMany().HasForeignKey(d => d.DistrictId);
        }
    }
}
