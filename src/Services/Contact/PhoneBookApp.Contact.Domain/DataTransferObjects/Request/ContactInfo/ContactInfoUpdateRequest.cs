using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo
{
    public class ContactInfoUpdateRequest
    {
        public Guid Id { get; set; }
        public ContactInfoType InfoType { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;

        public ContactInfoUpdateRequest()
        {
            
        }
        
        public ContactInfoUpdateRequest(Guid id, ContactInfoType infoType, string? title, string content)
        {
            Id = id;
            InfoType = infoType;
            Title = title;
            Content = content;
        }
    }
}