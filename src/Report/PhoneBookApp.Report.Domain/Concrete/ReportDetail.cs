using PhoneBookApp.Report.Domain.Abstract;
using PhoneBookApp.Shared.Core.Concrete;

namespace PhoneBookApp.Report.Domain.Concrete
{
    public class ReportDetail : BaseEntity, IReportDetail
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; } = string.Empty;
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }

        public virtual Report Report { get; set; } = null!;
    }
}
