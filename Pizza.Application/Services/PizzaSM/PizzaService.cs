using HashidsNet;
using Mapster;
using Pizza.Application.Localization;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Pizza;
using PizzaSM.Application.Services.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Pizza.Application.Services.PizzaSM;

public class PizzaService : ICrudService<PizzaRequestModel, PizzaResponseModel, PizzaUpdateModel>
{
    private readonly IRepository<PizzaM> _pizzaRepository;
    private readonly IHashids _hashId;

    public PizzaService(IRepository<PizzaM> pizzaRepository, IHashids hashids)
    {
        _pizzaRepository = pizzaRepository;
        _hashId = hashids;
    }

    public async Task Create(PizzaRequestModel model)
    {
        await _pizzaRepository.Create(model.Adapt<PizzaM>());
    }

    public async Task Delete(string id)
    {
        var rawId = _hashId.Decode(id);
        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        await _pizzaRepository.Delete(rawId[0]);
    }

    public async Task<PizzaResponseModel> Get(string id)
    {
        var rawId = _hashId.Decode(id);
        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        var pizza = await _pizzaRepository.Get(rawId[0]);

        return pizza is null ? throw new ResourceNotFound(ErrorMessages.NotFound) : pizza.Adapt<PizzaResponseModel>();
    }

    public async Task<List<PizzaResponseModel>> GetAll()
    {
        var pizzas = await _pizzaRepository.GetAll();
        return pizzas.Adapt<List<PizzaResponseModel>>();
    }

    public async Task Update(PizzaUpdateModel model)
    {
        await _pizzaRepository.Update(model.Adapt<PizzaM>());
    }
}
