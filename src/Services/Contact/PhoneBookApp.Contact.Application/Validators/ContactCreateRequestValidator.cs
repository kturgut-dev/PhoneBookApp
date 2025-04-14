using FluentValidation;
using PhoneBookApp.Contact.Domain.DataTransferObjects.Request.Contact;

namespace PhoneBookApp.Contact.Application.Validators
{
    public class ContactCreateRequestValidator : AbstractValidator<ContactCreateRequest>
    {
        public ContactCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Company)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Nickname)
                .MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Nickname));

            RuleFor(x => x.Website)
                .MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Website));

            RuleFor(x => x.Note)
                .MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Note));
        }
    }
}
