using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Data.Mappings.Ad
{
    internal class City_Mapping : EntityTypeConfiguration<City>
    {
        public City_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("City");

            Property(t => t.Id).HasColumnName("CityId");

            Property(t => t.Name).HasMaxLength(30);
        }
    }
}
