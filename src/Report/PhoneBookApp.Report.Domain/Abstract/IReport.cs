using PhoneBookApp.Report.Domain.Enums;
using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Report.Domain.Abstract
{
    public interface IReport : IAuditableEntity
    {
        string Name { get; set; }
        DateTime RequestedAt { get; set; }
        ReportStatus Status { get; set; }
    }
}
