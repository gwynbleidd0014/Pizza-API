using FluentValidation;
using Pizza.Api.Infrastructure.Localization;
using Pizza.Application.Services.UserSM;

namespace Pizza.Api.Infrastructure.Validations
{
    public class UserValidator : AbstractValidator<UserRequestModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .Length(2, 20).WithMessage(ValidationMessages.Between + "2 - 20");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .Length(2, 30).WithMessage(ValidationMessages.Between + "2 - 30");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(ValidationMessages.Email);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .Matches(@"^5\d{8}$").WithMessage(ValidationMessages.Phone);
        }
    }
}
