using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Shared.Infrastructure.Abstract
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TModel> AddAsync(TModel entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TModel entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        Task<List<TModel>> GetAllAsync(
            Expression<Func<TModel, bool>> predicate,
            CancellationToken cancellationToken = default);
        
        DbSet<TModel> GetDbSet();
    }
}
