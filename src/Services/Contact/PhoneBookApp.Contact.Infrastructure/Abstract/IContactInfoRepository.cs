using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Shared.Infrastructure.Repositories.Abstract;

namespace PhoneBookApp.Contact.Infrastructure.Abstract
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {
    }
}
