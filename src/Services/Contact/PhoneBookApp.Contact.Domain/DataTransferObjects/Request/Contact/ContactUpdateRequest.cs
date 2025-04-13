namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact
{
    public record ContactUpdateRequest(
         Guid Id,
         string Name,
         string Surname,
         string Company,
         string? Nickname,
         string? Website,
         string? Note
     );
}
