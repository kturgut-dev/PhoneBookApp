using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo
{
    public record ContactInfoUpdateRequest(Guid Id, ContactInfoType InfoType, string? Title, string Content);
}
