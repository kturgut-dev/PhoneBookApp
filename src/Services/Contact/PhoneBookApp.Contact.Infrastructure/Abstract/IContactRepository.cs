using PhoneBookApp.Shared.Infrastructure.Repositories.Abstract;

namespace PhoneBookApp.Contact.Infrastructure.Abstract
{
    public interface IContactRepository : IRepository<Domain.Concrete.Contact>
    {
        Task<Domain.Concrete.Contact?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
