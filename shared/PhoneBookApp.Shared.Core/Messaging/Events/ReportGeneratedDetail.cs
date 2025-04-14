namespace PhoneBookApp.Shared.Core.Messaging.Events;

public class ReportGeneratedDetail
{
    public string Location { get; set; } = string.Empty;
    public int PersonCount { get; set; }
    public int PhoneNumberCount { get; set; }
    public string RawDataJson { get; set; } = string.Empty;
}