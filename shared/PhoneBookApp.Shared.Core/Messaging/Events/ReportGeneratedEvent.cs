namespace PhoneBookApp.Shared.Core.Messaging.Events;

public class ReportGeneratedEvent
{
    public Guid ReportId { get; set; }
    public List<ReportGeneratedDetail> Details { get; set; } = new();
}