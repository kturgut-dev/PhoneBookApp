using PhoneBookApp.Report.Domain.DataTransferObjects.Response;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Report.Application.Abstract
{
    public interface IReportService
    {
        Task<Result<Guid>> StartReportAsync(string name, CancellationToken cancellationToken = default);
        Task<Result<string>> GetStatusAsync(Guid id, CancellationToken cancellationToken = default);
        
        Task<Result<List<ReportResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<ReportResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
