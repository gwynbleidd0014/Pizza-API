using FluentValidation;
using Pizza.Api.Infrastructure.Localization;
using Pizza.Application.Services.UserSM;

namespace Pizza.Api.Infrastructure.Validations;

public class UserUpdateValidator : AbstractValidator<UserUpdateModel>
{
    public UserUpdateValidator()
    {
        RuleFor(x => x.FirstName)
            .Length(2, 20).WithMessage(ValidationMessages.Between + "2 - 20");
        RuleFor(x => x.LastName)
            .Length(2, 30).WithMessage(ValidationMessages.Between + "2 - 30");
        RuleFor(x => x.Email)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(ValidationMessages.Email);
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^5\d{8}$").WithMessage(ValidationMessages.Phone);
    }
}
