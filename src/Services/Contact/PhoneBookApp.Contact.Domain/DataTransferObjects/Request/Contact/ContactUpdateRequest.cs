namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact
{
    public class ContactUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string? Nickname { get; set; }
        public string? Website { get; set; }
        public string? Note { get; set; }
    }

}
