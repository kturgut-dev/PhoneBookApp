using FluentValidation.TestHelper;
using PhoneBookApp.Contact.Application.Validators;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;

namespace PhoneBookApp.Contact.Tests.Validators
{
    public class ContactCreateRequestValidatorTests
    {
        private readonly ContactCreateRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new ContactCreateRequest("", "Turgut", "TurgutSoft", null, null, null);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Valid()
        {
            var model = new ContactCreateRequest("Kürşat", "Turgut", "TurgutSoft", "KT", "https://kursatturgut.com", "CEO");
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
