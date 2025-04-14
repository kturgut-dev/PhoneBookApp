namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact
{
    public class ContactCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string? Nickname { get; set; }
        public string? Website { get; set; }
        public string? Note { get; set; }

        public ContactCreateRequest()
        {
            
        }
        
        public ContactCreateRequest(string name, string surname, string company, string? nickname, string? website, string? note)
        {
            Name = name;
            Surname = surname;
            Company = company;
            Nickname = nickname;
            Website = website;
            Note = note;
        }
    }
}