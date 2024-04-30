using HashidsNet;
using PizzaSM.Application.Services.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Pizza;

public class PizzaRequestExample : IExamplesProvider<PizzaRequestModel>
{
    private readonly IHashids _hashId;

    public PizzaRequestExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public PizzaRequestModel GetExamples()
    {
        return new PizzaRequestModel()
        {
            Name = "Peperoni",
            Price = 20,
            CaloryCount = 450,
            Description = "Peperoni Pizza Straight from Italy"
        };
    }
}