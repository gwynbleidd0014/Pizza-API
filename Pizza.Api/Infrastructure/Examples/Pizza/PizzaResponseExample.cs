using HashidsNet;
using PizzaSM.Application.Services.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Pizza;

public class PizzaResponseExample : IExamplesProvider<PizzaResponseModel>
{
    private readonly IHashids _hashId;

    public PizzaResponseExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public PizzaResponseModel GetExamples()
    {
       return new PizzaResponseModel()
        {
            Id = _hashId.Encode(2000),
            Name = "Peperoni",
            Price = 20,
            CaloryCount = 450,
            Description = "Peperoni Pizza Straight from Italy",
            AverageRank = 7
        };
    }
}
