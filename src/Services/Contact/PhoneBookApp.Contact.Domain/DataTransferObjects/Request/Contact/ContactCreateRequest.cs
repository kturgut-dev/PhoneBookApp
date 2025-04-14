namespace PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact
{
    public record ContactCreateRequest(
          string Name,
          string Surname,
          string Company,
          string? Nickname,
          string? Website,
          string? Note
      );
}
