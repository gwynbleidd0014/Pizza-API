using HashidsNet;
using Pizza.Application.Services.UserSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Examples.User;

public class UserRequestExample : IExamplesProvider<UserRequestModel>
{
    private readonly IHashids _hashId;
    public UserRequestExample(IHashids hashId)
    {
        _hashId = hashId;
    }
    public UserRequestModel GetExamples()
    {
        return new UserRequestModel()
        {
            FirstName = "Ucha",
            LastName = "Omiadze",
            Email = "SomeCoolEmail@gmail.com",
            PhoneNumber = "599999999"
        };
    }
}
