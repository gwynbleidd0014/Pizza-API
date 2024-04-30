using HashidsNet;
using Pizza.Application.Services.RankHistory;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.RankHistory;

public class RankHistoryResponseExample : IExamplesProvider<RankHistoryResponseModel>
{
    private readonly IHashids _hashId;

    public RankHistoryResponseExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public RankHistoryResponseModel GetExamples()
    {
        return new RankHistoryResponseModel()
        {
            Id = _hashId.Encode(2000),
            UserId = _hashId.Encode(2100),
            PizzaId = _hashId.Encode(2200),
            Rank = 8
        };
    }
}
