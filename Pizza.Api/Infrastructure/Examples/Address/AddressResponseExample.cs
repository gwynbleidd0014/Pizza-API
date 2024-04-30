using HashidsNet;
using Pizza.Application.Services.AddressSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Address;

public class AddressResponseExample : IExamplesProvider<AddressResponseModel>
{
    private readonly IHashids _hashId;
    public AddressResponseExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public AddressResponseModel GetExamples()
    {
        return new AddressResponseModel()
        {
            Id = _hashId.Encode(2000),
            UserId = _hashId.Encode(2100),
            City = "Rustavi",
            Country = "Gerogia",
            Region = "Qvemo Qartli",
            Description = "Second Enter",
            Orders = new() { _hashId.Encode(2200), _hashId.Encode(2300) }
        };
}
}
