using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Core.Abstract;
using PhoneBookApp.Shared.Infrastructure.Abstract;

namespace PhoneBookApp.Shared.Infrastructure.Concrete
{
    public abstract class BaseRepository<TModel>(DbContext context) : IRepository<TModel> where TModel : class, IEntity<Guid>, new()
    {
        protected readonly DbContext _context = context;
        protected readonly DbSet<TModel> _dbSet = context.Set<TModel>();

        public async Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TModel> AddAsync(TModel entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<bool> UpdateAsync(TModel entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            TModel? entity = await GetByIdAsync(id, cancellationToken);
            if (entity is null) return false;

            _dbSet.Remove(entity);
            return true;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
