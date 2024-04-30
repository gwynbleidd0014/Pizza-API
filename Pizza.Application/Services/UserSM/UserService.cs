using HashidsNet;
using Mapster;
using Pizza.Application.Localization;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Pizza;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Application.Services.UserSM;

public class UserService : ICrudService<UserRequestModel, UserResponseModel, UserUpdateModel>
{
    private readonly IRepository<UserM> _userRepository;
    private readonly IHashids _hashId;

    public UserService(IRepository<UserM> userRepository, IHashids hashId)
    {
        _userRepository = userRepository;
        _hashId = hashId;
    }

    public async Task Create(UserRequestModel model)
    {
        await _userRepository.Create(model.Adapt<UserM>());
    }

    public async Task Delete(string id)
    {
        var rawId = _hashId.Decode(id);

        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        await _userRepository.Delete(rawId[0]);
    }

    public async Task<UserResponseModel> Get(string id)
    {
        var rawId = _hashId.Decode(id);

        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        var user = await _userRepository.Get(rawId[0]);

        return user is null ? throw new ResourceNotFound(ErrorMessages.NotFound) : user.Adapt<UserResponseModel>();
    }

    public async Task<List<UserResponseModel>> GetAll()
    {
        var users = await _userRepository.GetAll();
        return users.Adapt<List<UserResponseModel>>();
    }

    public async Task Update(UserUpdateModel model)
    {
        await _userRepository.Update(model.Adapt<UserM>());
    }
}
