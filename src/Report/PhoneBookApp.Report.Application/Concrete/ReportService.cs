using AutoMapper;
using MassTransit;
using PhoneBookApp.Report.Application.Abstract;
using PhoneBookApp.Report.Domain.Enums;
using PhoneBookApp.Report.Infrastructure.Abstract;
using PhoneBookApp.Shared.Core.Messaging.Report;
using PhoneBookApp.Shared.Core.Utilities.Result;
using PhoneBookApp.Shared.Infrastructure.Abstract;

namespace PhoneBookApp.Report.Application.Concrete
{
    public class ReportService(IReportRepository _reportRepository, IMapper _mapper, IPublishEndpoint _publishEndpoint)
        : IReportService
    {
        public async Task<Result<Guid>> StartReportAsync(string name, CancellationToken cancellationToken = default)
        {
            Domain.Concrete.Report report = new Domain.Concrete.Report
            {
                Id = Guid.NewGuid(),
                Name = name,
                RequestedAt = DateTime.UtcNow,
                Status = ReportStatus.Preparing
            };

            await _reportRepository.AddAsync(report, cancellationToken);
            await _reportRepository.SaveChangesAsync(cancellationToken);

            await _publishEndpoint.Publish(new GenerateReportCommand
            {
                ReportId = report.Id,
                RequestedAt = report.RequestedAt
            });

            return Result<Guid>.Success(report.Id);
        }

        public async Task<Result<string>> GetStatusAsync(Guid id, CancellationToken cancellationToken = default)
        {
            Domain.Concrete.Report? report = await _reportRepository.GetByIdAsync(id, cancellationToken);
            if (report is null)
                return Result<string>.Fail("Rapor bulunamadı");

            return Result<string>.Success(report.Status.ToString());
        }
    }
}