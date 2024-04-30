namespace Pizza.Application.Exceptions;

public class NoSuchPizzaInUsersOrders: CustomException
{
    public NoSuchPizzaInUsersOrders(string msg) : base(msg)
    {
        
    }
}
