using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Report.Domain.Concrete;
using PhoneBookApp.Report.Domain.Enums;
using PhoneBookApp.Report.Infrastructure.Context;
using PhoneBookApp.Shared.Core.Messaging.Events;

namespace PhoneBookApp.Report.Application.Messaging.Consumers;

public class ReportGeneratedEventConsumer(ReportDbContext _reportDbContext) : IConsumer<ReportGeneratedEvent>
{
    public async Task Consume(ConsumeContext<ReportGeneratedEvent> context)
    {
        List<ReportDetail> details = context.Message.Details.Select(x => new ReportDetail
        {
            ReportId = context.Message.ReportId, 
            Location = x.Location,
            PersonCount = x.PersonCount,
            PhoneNumberCount = x.PhoneNumberCount,
        }).ToList();

        await _reportDbContext.ReportDetails.AddRangeAsync(details);

        Domain.Concrete.Report? report = await _reportDbContext.Reports.FirstOrDefaultAsync(x => x.Id == context.Message.ReportId);
        if (report != null)
        {
            report.Status = ReportStatus.Completed;
        }

        await _reportDbContext.SaveChangesAsync();
    }
}