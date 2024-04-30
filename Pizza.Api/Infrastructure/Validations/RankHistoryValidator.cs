using FluentValidation;
using Pizza.Application.Services.RankHistory;

namespace Pizza.Api.Infrastructure.Validations;

public class RankHistoryValidator : AbstractValidator<RankHistoryRequestModel>
{
    public RankHistoryValidator()
    {
        RuleFor(x => x.Rank)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(10);
    }
}
