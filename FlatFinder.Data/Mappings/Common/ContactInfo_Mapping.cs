using FlatFinder.Core.Domain.User;
using System.Data.Entity.ModelConfiguration;
namespace FlatFinder.Data.Mappings.Common
{
    internal class ContactInfo_Mapping: EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfo_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("ContactInfo");

            Property(t => t.Id).HasColumnName("ContactInfoId");
        }
    }
}
