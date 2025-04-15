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
        Console.WriteLine($"[REPORT API] TETIKLENDI: {context.Message.ReportId}");
        
        List<ReportDetail> details = context.Message.Details.Select(x => new ReportDetail
        {
            ReportId = context.Message.ReportId, 
            Location = x.Location,
            PersonCount = x.PersonCount,
            PhoneNumberCount = x.PhoneNumberCount,
        }).ToList();
        
        Console.WriteLine($"ReportGeneratedEventConsumer: ReportId: {context.Message.ReportId}, Details Count: {details.Count}");

        await _reportDbContext.ReportDetails.AddRangeAsync(details);

        Domain.Concrete.Report? report = await _reportDbContext.Reports.FirstOrDefaultAsync(x => x.Id == context.Message.ReportId);
        if (report != null)
        {
            report.Status = ReportStatus.Completed;
            _reportDbContext.Reports.Update(report);
        }

        await _reportDbContext.SaveChangesAsync();
    }
}