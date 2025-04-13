using PhoneBookApp.Contact.Domain.Enums;
using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Contact.Domain.Abstract
{
    internal interface IContactInfo : IEntity<Guid>
    {
        Guid ContactId { get; set; }

        /// <summary>
        /// Info type (phone, email, location).
        /// </summary>
        ContactInfoType InfoType { get; set; }

        string? Title { get; set; }

        string Content { get; set; }
    }
}
