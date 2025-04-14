using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Report.Domain.Abstract
{
    public interface IReportDetail : IEntity<Guid>
    {
        Guid ReportId { get; set; }
        string Location { get; set; }
        int PersonCount { get; set; }
        int PhoneNumberCount { get; set; }
    }
}
