using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Concrete;

namespace PhoneBookApp.Contact.Infrastructure.Concrete
{
    public class ContactRepository : BaseRepository<Domain.Concrete.Contact>, IContactRepository
    {
        public ContactRepository(ContactDbContext context) : base(context) { }

        public async Task<Domain.Concrete.Contact?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.ContactInfos)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
