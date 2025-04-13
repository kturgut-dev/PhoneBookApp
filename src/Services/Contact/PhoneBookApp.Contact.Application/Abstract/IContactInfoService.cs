using PhoneBookApp.Contact.Domain.Concrete;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;
using PhoneBookApp.Shared.Application.Abstract;

namespace PhoneBookApp.Contact.Application.Abstract
{
    public interface IContactInfoService : IBaseService<ContactInfo, ContactInfoCreateRequest, ContactInfoUpdateRequest, ContactInfoResponse>
    {
    }
}
