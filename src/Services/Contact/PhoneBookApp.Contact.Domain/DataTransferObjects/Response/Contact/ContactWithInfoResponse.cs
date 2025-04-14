using PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact
{
    public class ContactWithInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Company { get; set; } = null!;

        public string? Nickname { get; set; }

        public string? Website { get; set; }

        public string? Note { get; set; }

        public List<ContactInfoResponse> ContactInfos { get; set; } = [];
    }
}
