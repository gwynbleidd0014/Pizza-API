using HashidsNet;
using Pizza.Application.Services.PizzaSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Pizza;

public class PizzaUpdateExample : IExamplesProvider<PizzaUpdateModel>
{
    private readonly IHashids _hashId;

    public PizzaUpdateExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public PizzaUpdateModel GetExamples()
    {
        return new PizzaUpdateModel()
        {
            Id = _hashId.Encode(2000),
            Name = "Peperoni",
            Price = 20,
            CaloryCount = 450,
            Description = null
        };
    }
}