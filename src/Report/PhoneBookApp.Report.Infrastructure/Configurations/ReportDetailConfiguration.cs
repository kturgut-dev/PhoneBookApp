using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApp.Report.Domain.Concrete;

namespace PhoneBookApp.Report.Infrastructure.Configurations
{
    public class ReportDetailConfiguration : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.Property(x => x.Location).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PersonCount).IsRequired();
            builder.Property(x => x.PhoneNumberCount).IsRequired();
        }
    }
}
