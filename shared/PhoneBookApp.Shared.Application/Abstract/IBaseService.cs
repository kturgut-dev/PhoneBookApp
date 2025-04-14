using PhoneBookApp.Shared.Core.Abstract;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Shared.Application.Abstract
{
    public interface IBaseService<TModel, TCreateRequest, TUpdateRequest, TResponse>
    where TModel : IEntity<Guid>
    {
        Task<Result<TResponse>> AddAsync(TCreateRequest request, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TUpdateRequest request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TResponse?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<List<TResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
