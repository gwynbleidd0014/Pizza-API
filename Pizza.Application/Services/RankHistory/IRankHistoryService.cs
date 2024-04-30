using Pizza.Application.Services.OrderSM;

namespace Pizza.Application.Services.RankHistory;

public interface IRankHistoryService
{
    Task<List<RankHistoryResponseModel>> GetAll();
    Task<RankHistoryResponseModel> Get(string id);
    Task Create(RankHistoryRequestModel model);
}
