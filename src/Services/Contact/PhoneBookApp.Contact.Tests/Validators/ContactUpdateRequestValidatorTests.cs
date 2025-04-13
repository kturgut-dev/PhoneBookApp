using FluentValidation.TestHelper;
using PhoneBookApp.Contact.Application.Validators;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;

namespace PhoneBookApp.Contact.Tests.Validators
{
    public class ContactUpdateRequestValidatorTests
    {
        private readonly ContactUpdateRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var model = new ContactUpdateRequest(Guid.Empty, "Kürşat", "Turgut", "TurgutSoft", null, null, null);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
