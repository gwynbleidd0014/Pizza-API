namespace Pizza.Application.Services.OrderSM;

public interface IOrderService
{
    Task<List<OrderResponseModel>> GetAll();
    Task<OrderResponseModel> Get(string id);
    Task Create(OrderRequestModel model);

}
