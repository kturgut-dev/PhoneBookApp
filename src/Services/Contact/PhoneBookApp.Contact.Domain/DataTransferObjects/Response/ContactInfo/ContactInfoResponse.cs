using System.Text.Json.Serialization;
using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Response.ContactInfo
{
    public class ContactInfoResponse
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContactInfoType InfoType { get; set; }

        public string? Title { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
