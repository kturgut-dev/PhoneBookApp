using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Shared.Application.Abstract;
using PhoneBookApp.Shared.Core.Abstract;
using PhoneBookApp.Shared.Core.Utilities.Result;
using PhoneBookApp.Shared.Infrastructure.Abstract;

namespace PhoneBookApp.Shared.Application.Concrete
{
    public abstract class BaseService<TModel, TCreateRequest, TUpdateRequest, TResponse> :
         IBaseService<TModel, TCreateRequest, TUpdateRequest, TResponse>
         where TModel : class, IEntity<Guid>, new()
    {
        protected readonly IRepository<TModel> _repository;
        protected readonly IMapper _mapper;
        protected readonly DbContext _context;

        protected BaseService(IRepository<TModel> repository, IMapper mapper, DbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public virtual async Task<Result<TResponse>> AddAsync(TCreateRequest request, CancellationToken cancellationToken = default)
        {
            TModel entity = _mapper.Map<TModel>(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            TResponse response = _mapper.Map<TResponse>(entity);
            return Result<TResponse>.Success(response, "Created successfully.");
        }

        public virtual async Task<Result> UpdateAsync(TUpdateRequest request, CancellationToken cancellationToken = default)
        {
            TModel entity = _mapper.Map<TModel>(request);
            bool updated = await _repository.UpdateAsync(entity, cancellationToken);

            if (!updated)
                return Result.Fail("Update failed.");

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success("Updated successfully.");
        }

        public virtual async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            bool deleted = await _repository.DeleteAsync(id, cancellationToken);

            if (!deleted)
                return Result.Fail("Delete failed.");

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success("Deleted successfully.");
        }

        public virtual async Task<Result<TResponse?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            TModel? entity = await _repository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return Result<TResponse?>.Fail("Record not found.");

            TResponse response = _mapper.Map<TResponse>(entity);
            return Result<TResponse?>.Success(response);
        }

        public virtual async Task<Result<List<TResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<TModel> list = await _repository.GetAllAsync(cancellationToken);
            List<TResponse> responseList = _mapper.Map<List<TResponse>>(list);
            return Result<List<TResponse>>.Success(responseList);
        }
    }
}
