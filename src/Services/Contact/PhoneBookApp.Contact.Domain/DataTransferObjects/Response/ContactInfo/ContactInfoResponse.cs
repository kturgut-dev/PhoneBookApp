using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo
{
    public record ContactInfoResponse(Guid Id, ContactInfoType InfoType, string? Title, string Content);
}
