using HashidsNet;
using Pizza.Application.Services.UserSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.User;

public class UserResponseExample : IExamplesProvider<UserResponseModel>
{
    private readonly IHashids _hashId;
    public UserResponseExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public UserResponseModel GetExamples()
    {
        return new UserResponseModel()
        {
            Id = _hashId.Encode(2000),
            FirstName = "Ucha",
            LastName = "Omiadze",
            Email = "SomeCoolEmail@gmail.com",
            PhoneNumber = "599999999",
            Address = new() { _hashId.Encode(2100), _hashId.Encode(2200) },
            Orders = new() { _hashId.Encode(2300), _hashId.Encode(2400) }
        };
    }
}
