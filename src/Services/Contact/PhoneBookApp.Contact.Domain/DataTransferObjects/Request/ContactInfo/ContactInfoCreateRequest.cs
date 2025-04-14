using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo
{
    public class ContactInfoCreateRequest
    {
        public Guid ContactId { get; set; }
        public ContactInfoType InfoType { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}