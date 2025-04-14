using PhoneBookApp.Report.Domain.Abstract;
using PhoneBookApp.Report.Domain.Enums;
using PhoneBookApp.Shared.Core.Concrete;

namespace PhoneBookApp.Report.Domain.Concrete
{
    public class Report : AuditableEntity, IReport
    {
        public string Name { get; set; } = null!;
        public DateTime RequestedAt { get; set; }
        public ReportStatus Status { get; set; } = ReportStatus.Preparing;

        public virtual ICollection<ReportDetail> ReportDetails { get; set; } = new List<ReportDetail>();
    }
}
