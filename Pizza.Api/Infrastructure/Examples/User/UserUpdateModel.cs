using HashidsNet;
using Pizza.Application.Services.UserSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples;

public class UserUpdateExample : IExamplesProvider<UserUpdateModel>
{
    private readonly IHashids _hashId;
    public UserUpdateExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public UserUpdateModel GetExamples()
    {
        return new UserUpdateModel()
        {
            Id = _hashId.Encode(2000),
            FirstName = "Ucha",
            LastName = null,
            Email = "SomeCoolEmail@gmail.com",
            PhoneNumber = "599999999",
        };
    }
}
