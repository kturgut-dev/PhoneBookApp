using PhoneBookApp.Report.Domain.Concrete;
using PhoneBookApp.Report.Infrastructure.Abstract;
using PhoneBookApp.Report.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Concrete;

namespace PhoneBookApp.Report.Infrastructure.Concrete
{
    public class ReportDetailRepository : BaseRepository<ReportDetail>, IReportDetailRepository
    {
        public ReportDetailRepository(ReportDbContext context) : base(context) { }
    }
}
