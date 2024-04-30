namespace Pizza.Application.Services.OrderSM;

public class OrderResponseModel
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string AddressId { get; set; }
    public List<string> PizzaIds { get; set; }
}
