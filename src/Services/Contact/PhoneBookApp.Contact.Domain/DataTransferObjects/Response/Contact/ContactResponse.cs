namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Response.Contact
{
    public record ContactResponse(
            Guid Id,
            string Name,
            string Surname,
            string Company,
            string? Nickname,
            string? Website,
            string? Note
        );
}
