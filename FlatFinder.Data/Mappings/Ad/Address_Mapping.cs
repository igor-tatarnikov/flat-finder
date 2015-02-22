using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Data.Mappings.Ad
{
    internal class Address_Mapping : EntityTypeConfiguration<Address>
    {
        public Address_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("Address");

            Property(t => t.Id).HasColumnName("AddressId");

            Property(t => t.Street).HasMaxLength(70);

            HasRequired(t => t.City).WithMany().HasForeignKey(d => d.CityId);
            HasOptional(t => t.District).WithMany().HasForeignKey(d => d.DistrictId);
        }
    }
}
