namespace Pizza.Application.Services.AddressSM;

public class AddressResponseModel
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    public List<string> Orders { get; set; }
}
