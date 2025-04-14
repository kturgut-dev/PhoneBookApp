using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Report.Domain.Concrete;
using PhoneBookApp.Shared.Infrastructure.Context;

namespace PhoneBookApp.Report.Infrastructure.Context
{
    public class ReportDbContext(DbContextOptions<ReportDbContext> options) : BaseDbContext(options)
    {
        public DbSet<Domain.Concrete.Report> Reports => Set<Domain.Concrete.Report>();
        public DbSet<ReportDetail> ReportDetails => Set<ReportDetail>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReportDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
