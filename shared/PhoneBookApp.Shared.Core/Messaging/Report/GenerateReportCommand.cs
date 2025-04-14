namespace PhoneBookApp.Shared.Core.Messaging.Report;

public class GenerateReportCommand
{
    public Guid ReportId { get; set; }
    public DateTime RequestedAt { get; set; }
}