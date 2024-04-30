using HashidsNet;
using Pizza.Application.Services.RankHistory;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.RankHistory;

public class RankHistoryRequestExample : IExamplesProvider<RankHistoryRequestModel>
{
    private readonly IHashids _hashId;

    public RankHistoryRequestExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public RankHistoryRequestModel GetExamples()
    {
        return new RankHistoryRequestModel()
        {
            UserId = _hashId.Encode(2100),
            PizzaId = _hashId.Encode(2200),
            Rank = 8
        };
    }
}
