using HashidsNet;
using Pizza.Application.Services.AddressSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Address;

public class AddressRequestExample : IExamplesProvider<AddressRequestModel>
{
    private readonly IHashids _hashId;
    public AddressRequestExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public AddressRequestModel GetExamples()
    {
        return new AddressRequestModel()
        {
            UserId = _hashId.Encode(2100),
            City = "Rustavi",
            Country = "Gerogia",
            Region = "Qvemo Qartli",
            Description = "Second Enter",
        };
    }
}