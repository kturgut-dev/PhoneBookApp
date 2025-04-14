using PhoneBookApp.Report.Infrastructure.Abstract;
using PhoneBookApp.Report.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Concrete;

namespace PhoneBookApp.Report.Infrastructure.Concrete
{
    public class ReportRepository : BaseRepository<Domain.Concrete.Report>, IReportRepository
    {
        public ReportRepository(ReportDbContext context) : base(context) { }
    }
}
