using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApp.Contact.Domain.Concrete;

namespace PhoneBookApp.Contact.Infrastructure.Configurations
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {

            builder.Property(x => x.ContactId)
                .IsRequired();

            builder.Property(x => x.InfoType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.Title)
                .HasMaxLength(100);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(x => x.Contact)
                .WithMany(x => x.ContactInfos)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
