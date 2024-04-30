using HashidsNet;
using Mapster;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Application.Services.OrderSM
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderM> _repository;
        private readonly IHashids _hashId;
        public OrderService(IRepository<OrderM> repository, IHashids hashids)
        {
            _repository = repository;
            _hashId = hashids;
        }

        public async Task Create(OrderRequestModel model)
        {
            await _repository.Create(model.Adapt<OrderM>());
        }

        public async Task<OrderResponseModel> Get(string id)
        {
            var rawId = _hashId.Decode(id);
            if (rawId.Length == 0)
                throw new ResourceNotFound(ErrorMessages.NotFound);

            var order = await _repository.Get(rawId[0]);

            return order.Adapt<OrderResponseModel>();
        }

        public async Task<List<OrderResponseModel>> GetAll()
        {
            var orders = await _repository.GetAll();
            return orders.Adapt<List<OrderResponseModel>>();
        }


    }
}
