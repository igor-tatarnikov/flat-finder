using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FlatFinder.Core.Domain.User;

namespace FlatFinder.Data.Mappings.User
{
    internal class ContactInfo_Mapping: EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfo_Mapping()
        {
            HasKey(t => t.Id);
            ToTable("ContactInfo");

            Property(t => t.Id).HasColumnName("ContactInfoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
