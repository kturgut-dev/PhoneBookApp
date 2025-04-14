using PhoneBookApp.Contact.Domain.Abstract;
using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Shared.Core.Concrete;

namespace PhoneBookApp.Contact.Domain.Concrete
{
    public class ContactInfo : BaseEntity, IContactInfo
    {
        public Guid ContactId { get; set; }
        public ContactInfoType InfoType { get; set; } // Location, Phone, Address vb
        public string? Title { get; set; }
        public string Content { get; set; } = null!;

        public virtual Contact? Contact { get; set; }
    }
}
