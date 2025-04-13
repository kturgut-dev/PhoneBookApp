using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact;
using PhoneBookApp.Shared.Application.Abstract;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Contact.Application.Abstract
{
    public interface IContactService : IBaseService<Domain.Concrete.Contact, ContactCreateRequest, ContactUpdateRequest, ContactResponse>
    {
        Task<Result<ContactWithInfoResponse?>> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
