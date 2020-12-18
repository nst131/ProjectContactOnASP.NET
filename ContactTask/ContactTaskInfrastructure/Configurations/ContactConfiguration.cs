using ContactTaskDomain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ContactTaskInfrastructure.Configurations
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            ToTable("Contact");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
