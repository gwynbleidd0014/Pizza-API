using Pizza.Domain.Models;

namespace PizzaSM.Application.Services.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task Delete(int id);
    Task Create(T model);
    Task Update(T model);
}
