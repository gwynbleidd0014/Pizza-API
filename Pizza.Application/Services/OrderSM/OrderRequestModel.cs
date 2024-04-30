namespace Pizza.Application.Services.OrderSM;

public class OrderRequestModel
{
    public string UserId { get; set; }
    public string AddressId { get; set; }
    public List<string> PizzaIds { get; set; }
}
