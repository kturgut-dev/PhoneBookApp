using System.Text.Json;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Core.Messaging.Events;
using PhoneBookApp.Shared.Core.Messaging.Report;

namespace PhoneBookApp.Contact.Application.Messaging.Consumers;

public class GenerateReportCommandConsumer(ContactDbContext _contactDbContext, IPublishEndpoint _publishEndpoint)
    : IConsumer<GenerateReportCommand>
{
    public async Task Consume(ConsumeContext<GenerateReportCommand> context)
    {
        List<string>? locations = await _contactDbContext.ContactInfos
            .Where(x => x.InfoType == ContactInfoType.Location)
            .Select(x => x.Content)
            .Distinct()
            .ToListAsync();

        List<ReportGeneratedDetail> details = new List<ReportGeneratedDetail>();

        foreach (string location in locations)
        {
            List<Guid> contactIds = await _contactDbContext.ContactInfos
                .Where(x => x.InfoType == ContactInfoType.Location && x.Content == location.Trim())
                .Select(x => x.ContactId)
                .Distinct()
                .ToListAsync();

            List<Domain.Concrete.Contact> persons = await _contactDbContext.Contacts
                .Where(x => contactIds.Contains(x.Id))
                .ToListAsync();

            int phoneCount = await _contactDbContext.ContactInfos
                .CountAsync(x => x.InfoType == ContactInfoType.PhoneNumber && contactIds.Contains(x.ContactId));

            if (!details.Any(x => x.Location.Equals(location.Trim())))
                details.Add(new ReportGeneratedDetail
                {
                    Location = location.Trim(),
                    PersonCount = persons.Count,
                    PhoneNumberCount = phoneCount,
                });
        }

        // thread sleep for 5 seconds - uzun sürmesi için
        await Task.Delay(5000);

        Console.WriteLine(
            $"GenerateReportCommandConsumer: ReportId: {context.Message.ReportId}, Details Count: {details.Count}");

        await _publishEndpoint.Publish(new ReportGeneratedEvent
        {
            ReportId = context.Message.ReportId,
            Details = details
        });
    }
}