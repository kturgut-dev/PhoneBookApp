using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Report.Application.Abstract
{
    public interface IReportService
    {
        Task<Result<Guid>> StartReportAsync(string name, CancellationToken cancellationToken = default);
        Task<Result<string>> GetStatusAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
