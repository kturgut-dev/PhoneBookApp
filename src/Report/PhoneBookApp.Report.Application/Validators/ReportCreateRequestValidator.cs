using FluentValidation;
using PhoneBookApp.Report.Domain.DataTransferObjects.Request;

namespace PhoneBookApp.Report.Application.Validators
{
    public class ReportCreateRequestValidator : AbstractValidator<ReportCreateRequest>
    {
        public ReportCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
