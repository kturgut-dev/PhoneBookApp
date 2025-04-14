using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneBookApp.Contact.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<PhoneBookApp.Contact.Domain.Concrete.Contact>
    {
        public void Configure(EntityTypeBuilder<PhoneBookApp.Contact.Domain.Concrete.Contact> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Company)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Nickname)
                .HasMaxLength(100);

            builder.Property(x => x.Website)
                .HasMaxLength(200);

            builder.Property(x => x.Note)
                .HasMaxLength(500);

            builder.HasMany(x => x.ContactInfos)
                .WithOne(x => x.Contact)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
