using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhoneBookApp.Report.Infrastructure.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Domain.Concrete.Report>
    {
        public void Configure(EntityTypeBuilder<Domain.Concrete.Report> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.RequestedAt).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.ReportDetails)
                   .WithOne(x => x.Report)
                   .HasForeignKey(x => x.ReportId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
