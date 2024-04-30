using FluentValidation;
using Pizza.Api.Infrastructure.Localization;
using Pizza.Application.Services.AddressSM;

namespace Pizza.Api.Infrastructure.Validations;

public class AddressUpdateValidator : AbstractValidator<AddressUpdateModel>
{
    public AddressUpdateValidator()
    {
        RuleFor(x => x.City)
            .MaximumLength(15).WithMessage(ValidationMessages.LessThan + "15");
        RuleFor(x => x.Country)
            .MaximumLength(15).WithMessage(ValidationMessages.LessThan + "15");
        RuleFor(x => x.Region)
            .MaximumLength(15).WithMessage(ValidationMessages.LessThan + "15");
        RuleFor(x => x.Description)
            .MaximumLength(100).WithMessage(ValidationMessages.LessThan + "100");
    }
}
