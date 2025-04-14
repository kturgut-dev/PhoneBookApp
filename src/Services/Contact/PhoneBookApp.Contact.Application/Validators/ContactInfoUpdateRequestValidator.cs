using FluentValidation;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.ContactInfo;

namespace PhoneBookApp.Contact.Application.Validators
{
    public class ContactInfoUpdateRequestValidator : AbstractValidator<ContactInfoUpdateRequest>
    {
        public ContactInfoUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.InfoType)
                .IsInEnum();

            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Title)
                .MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Title));
        }
    }
}
