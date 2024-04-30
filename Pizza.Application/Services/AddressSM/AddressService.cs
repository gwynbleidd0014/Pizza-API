using HashidsNet;
using Mapster;
using Pizza.Application.Localization;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Application.Services.AddressSM;

public class AddressService : ICrudService<AddressRequestModel, AddressResponseModel, AddressUpdateModel>
{
    private readonly IRepository<AddressM> _addressRepository;
    private readonly IHashids _hashId;

    public AddressService(IRepository<AddressM> userRepository, IHashids hashId)
    {
        _addressRepository = userRepository;
        _hashId = hashId;
    }
    public async  Task Create(AddressRequestModel model)
    {
        await _addressRepository.Create(model.Adapt<AddressM>());
    }

    public async Task Delete(string id)
    {
        var rawId = _hashId.Decode(id);

        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        await _addressRepository.Delete(rawId[0]);
    }

    public async Task<AddressResponseModel> Get(string id)
    {
        var rawId = _hashId.Decode(id);

        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        var user = await _addressRepository.Get(rawId[0]);

        return user is null ? throw new ResourceNotFound(ErrorMessages.NotFound) : user.Adapt<AddressResponseModel>();
    }

    public async Task<List<AddressResponseModel>> GetAll()
    {
        var users = await _addressRepository.GetAll();
        return users.Adapt<List<AddressResponseModel>>();
    }

    public async Task Update(AddressUpdateModel model)
    {
        await _addressRepository.Update(model.Adapt<AddressM>());
    }
}
