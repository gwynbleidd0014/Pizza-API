using FluentValidation;
using Pizza.Api.Infrastructure.Localization;
using Pizza.Application.Services.PizzaSM;

namespace Pizza.Api.Infrastructure.Validations;

public class PizzaUpdateValidator : AbstractValidator<PizzaUpdateModel>
{
    public PizzaUpdateValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 20).WithMessage(ValidationMessages.Between + "3 - 20");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanZero);
        RuleFor(x => x.Description)
            .MaximumLength(100).WithMessage(ValidationMessages.LessThan + "100");
        RuleFor(x => x.CaloryCount)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanZero);
    }
}
