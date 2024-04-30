using HashidsNet;
using Pizza.Application.Services.OrderSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Order;

public class OrderRequestExample : IExamplesProvider<OrderRequestModel>
{
    private readonly IHashids _hashId;

    public OrderRequestExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public OrderRequestModel GetExamples()
    {
        return new OrderRequestModel()
        {
            UserId = _hashId.Encode(2100),
            AddressId = _hashId.Encode(2200),
            PizzaIds = new() { _hashId.Encode(2300), _hashId.Encode(2400) },

        };

    }
}
