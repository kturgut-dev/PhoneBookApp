using PhoneBookApp.Shared.Infrastructure.Abstract;

namespace PhoneBookApp.Report.Infrastructure.Abstract
{
    public interface IReportRepository : IRepository<Domain.Concrete.Report>
    {
    }
}
