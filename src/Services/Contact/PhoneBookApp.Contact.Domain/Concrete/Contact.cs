using PhoneBookApp.Contact.Domain.Abstract;
using PhoneBookApp.Shared.Core.Concrete;

namespace PhoneBookApp.Contact.Domain.Concrete
{
    public class Contact : AuditableEntity, IContact
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string? Nickname { get; set; }
        public string? Website { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<ContactInfo>? ContactInfos { get; set; }
    }
}
