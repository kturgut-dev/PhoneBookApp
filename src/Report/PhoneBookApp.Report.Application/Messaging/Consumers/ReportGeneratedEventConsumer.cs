using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Report.Domain.Concrete;
using PhoneBookApp.Report.Domain.Enums;
using PhoneBookApp.Report.Infrastructure.Context;
using PhoneBookApp.Shared.Core.Messaging.Events;

namespace PhoneBookApp.Report.Application.Messaging.Consumers;

public class ReportGeneratedEventConsumer : IConsumer<ReportGeneratedEvent>
{
    private readonly ReportDbContext _context;

    public ReportGeneratedEventConsumer(ReportDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<ReportGeneratedEvent> context)
    {
        var details = context.Message.Details.Select(x => new ReportDetail
        {
            ReportId = context.Message.ReportId,
            Location = x.Location,
            PersonCount = x.PersonCount,
            PhoneNumberCount = x.PhoneNumberCount,
        }).ToList();

        await _context.ReportDetails.AddRangeAsync(details);

        var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == context.Message.ReportId);
        if (report != null)
        {
            report.Status = ReportStatus.Completed;
        }

        await _context.SaveChangesAsync();
    }
}