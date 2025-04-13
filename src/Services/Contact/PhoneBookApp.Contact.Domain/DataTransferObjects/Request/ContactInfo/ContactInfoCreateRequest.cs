using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo
{
    public record ContactInfoCreateRequest(Guid ContactId, ContactInfoType InfoType, string? Title, string Content);
}
