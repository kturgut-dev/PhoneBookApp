namespace PhoneBookApp.Report.Domain.DataTransferObjects.Response
{
    public class ReportResponse
    {
        public Guid Id { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }

        public List<ReportDetailResponse> Details { get; set; } = new ();
    }
}
