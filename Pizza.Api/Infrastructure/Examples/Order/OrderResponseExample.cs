using HashidsNet;
using Pizza.Application.Services.OrderSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Order;

public class OrderResponseExample : IExamplesProvider<OrderResponseModel>
{
    private readonly IHashids _hashId;

    public OrderResponseExample(IHashids hashId)
    {
        _hashId = hashId;
    }

    public OrderResponseModel GetExamples()
    {
        return new OrderResponseModel()
        {
            Id = _hashId.Encode(2000),
            UserId = _hashId.Encode(2100),
            AddressId = _hashId.Encode(2200),
            PizzaIds = new() { _hashId.Encode(2300), _hashId.Encode(2400) },

        };

}
}
