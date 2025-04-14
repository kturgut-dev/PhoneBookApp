namespace PhoneBookApp.Report.Domain.DataTransferObjects.Request
{
    public class ReportCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}
