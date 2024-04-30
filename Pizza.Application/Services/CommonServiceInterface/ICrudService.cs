namespace Pizza.Application.Services.CommonServiceInterface;

public interface ICrudService<TRequest, TResponse, TUpdate> where TRequest : class where TResponse : class
{
    Task<List<TResponse>> GetAll();
    Task<TResponse> Get(string id);
    Task Create(TRequest model);
    Task Delete(string id);
    Task Update(TUpdate model);
}
