using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;
using PhoneBookApp.Shared.Application.Abstract;
using PhoneBookApp.Shared.Core.Utilities.Result;

namespace PhoneBookApp.Contact.Application.Abstract
{
    public interface IContactInfoService : IBaseService<ContactInfo, ContactInfoCreateRequest, ContactInfoUpdateRequest, ContactInfoResponse>
    {
        Task<Result<List<ContactInfoResponse>>> GetByContactIdAsync(Guid contactId, CancellationToken cancellationToken = default);

    }
}
