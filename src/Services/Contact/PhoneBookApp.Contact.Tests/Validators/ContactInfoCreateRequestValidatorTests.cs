using FluentValidation.TestHelper;
using PhoneBookApp.Contact.Application.Validators;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Tests.Validators
{
    public class ContactInfoCreateRequestValidatorTests
    {
        private readonly ContactInfoCreateRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Content_Is_Empty()
        {
            var model = new ContactInfoCreateRequest(Guid.NewGuid(), ContactInfoType.Email, "İş Mail", "");
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Content);
        }
    }
}
