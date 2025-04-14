using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Infrastructure.Abstract;
using PhoneBookApp.Contact.Infrastructure.Context;
using PhoneBookApp.Shared.Infrastructure.Concrete;

namespace PhoneBookApp.Contact.Infrastructure.Concrete
{
    public class ContactInfoRepository(ContactDbContext context) : BaseRepository<ContactInfo>(context), IContactInfoRepository
    {

    }
}
