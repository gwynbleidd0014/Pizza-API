using Pizza.Domain.Models;

namespace Pizza.Application.Services.UserSM;

public class UserResponseModel
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Address { get; set; }
    public List<string> Orders { get; set; }
}
