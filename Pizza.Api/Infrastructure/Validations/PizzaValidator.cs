using FluentValidation;
using Pizza.Api.Infrastructure.Localization;
using PizzaSM.Application.Services.Pizza;

namespace Pizza.Api.Infrastructure.Validations;

public class PizzaValidator : AbstractValidator<PizzaRequestModel>
{
    public PizzaValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(3, 20).WithMessage(ValidationMessages.Between + "3 - 20"); 
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanZero);
        RuleFor(x => x.Description)
            .MaximumLength(100).WithMessage(ValidationMessages.LessThan + "100");
        RuleFor(x => x.CaloryCount)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessages.GreaterThanZero);
    }
}
