using HashidsNet;
using Pizza.Application.Services.AddressSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.Address;

public class AddressUpdateExample : IExamplesProvider<AddressUpdateModel>
{
    private readonly IHashids _hashId;
    public AddressUpdateExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public AddressUpdateModel GetExamples()
    {
        return new AddressUpdateModel()
        {
            Id = _hashId.Encode(2000),
            UserId = _hashId.Encode(2100),
            City = "Rustavi",
            Country = "Gerogia",
            Region = null,
            Description = "Second Enter",
        };
    }
}