using FluentValidation.TestHelper;
using PhoneBookApp.Contact.Application.Validators;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;
using PhoneBookApp.Contact.Domain.Enums;

namespace PhoneBookApp.Contact.Tests.Validators
{
    public class ContactInfoUpdateRequestValidatorTests
    {
        private readonly ContactInfoUpdateRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            var model = new ContactInfoUpdateRequest(Guid.Empty, ContactInfoType.PhoneNumber, "Cep", "+90 532 000 00 00");
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
