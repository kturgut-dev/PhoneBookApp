using System.Text.Json;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Core.Messaging.Events;
using PhoneBookApp.Shared.Core.Messaging.Report;

namespace PhoneBookApp.Contact.Application.Messaging.Consumers;

public class GenerateReportCommandConsumer : IConsumer<GenerateReportCommand>
    {
        private readonly ContactDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public GenerateReportCommandConsumer(ContactDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<GenerateReportCommand> context)
        {
            var locations = await _context.ContactInfos
                .Where(x => x.InfoType == ContactInfoType.Location)
                .Select(x => x.Content)
                .Distinct()
                .ToListAsync();

            var details = new List<ReportGeneratedDetail>();

            foreach (var location in locations)
            {
                var contactIds = await _context.ContactInfos
                    .Where(x => x.InfoType == ContactInfoType.Location && x.Content == location)
                    .Select(x => x.ContactId)
                    .Distinct()
                    .ToListAsync();

                var persons = await _context.Contacts
                    .Where(x => contactIds.Contains(x.Id))
                    .ToListAsync();

                var phoneCount = await _context.ContactInfos
                    .CountAsync(x => x.InfoType == ContactInfoType.PhoneNumber && contactIds.Contains(x.ContactId));

                var rawData = JsonSerializer.Serialize(persons);

                details.Add(new ReportGeneratedDetail
                {
                    Location = location,
                    PersonCount = persons.Count,
                    PhoneNumberCount = phoneCount,
                    RawDataJson = rawData
                });
            }

            await _publishEndpoint.Publish(new ReportGeneratedEvent
            {
                ReportId = context.Message.ReportId,
                Details = details
            });
        }
    }