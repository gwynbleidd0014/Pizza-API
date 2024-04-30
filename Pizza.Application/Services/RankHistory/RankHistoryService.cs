using HashidsNet;
using Mapster;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Application.Services.RankHistory;

public class RankHistoryService : IRankHistoryService
{
    private readonly IRepository<RankHistoryM> _repository;
    private readonly IHashids _hashId;

    public RankHistoryService(IRepository<RankHistoryM> repository, IHashids hashId)
    {
        _repository = repository;
        _hashId = hashId;
    }

    public async Task Create(RankHistoryRequestModel model)
    {
       await _repository.Create(model.Adapt<RankHistoryM>());
    }

    public async Task<RankHistoryResponseModel> Get(string id)
    {
        var rawId = _hashId.Decode(id);

        if (rawId.Length == 0)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        return (await _repository.Get(rawId[0])).Adapt<RankHistoryResponseModel>();
    }

    public async Task<List<RankHistoryResponseModel>> GetAll()
    {
        return (await _repository.GetAll()).Adapt<List<RankHistoryResponseModel>>();
    }
}
