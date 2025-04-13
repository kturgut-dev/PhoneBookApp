using PhoneBookApp.Shared.Core.Abstract;

namespace PhoneBookApp.Contact.Domain.Abstract
{
    public interface IContact : IAuditableEntity
    {
        string Name { get; set; }

        string Surname { get; set; }

        /// <summary>
        /// Company or organization
        /// </summary>
        string Company { get; set; }

        /// <summary>
        /// Optional nickname or alias for the contact
        /// </summary>
        string? Nickname { get; set; }

        /// <summary>
        /// Website URL
        /// </summary>
        string? Website { get; set; }

        /// <summary>
        /// Business or office address
        /// </summary>
        string? WorkAddress { get; set; }

        /// <summary>
        /// Additional notes or description
        /// </summary>
        string? Note { get; set; }
    }
}
