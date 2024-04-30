using Microsoft.EntityFrameworkCore;
using Pizza.Application.Exceptions;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Infrastructure.Repositories;

public class RankHistoryRepository : IRepository<RankHistoryM>
{
    private readonly ApplicationDbContext _db;

    public RankHistoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task Create(RankHistoryM model)
    {
        var user = await _db.Users.Include(x => x.Orders).ThenInclude(x=> x.Pizzas).SingleOrDefaultAsync(x => x.Id == model.UserId && !x.IsDeleted);
        if (user == null)
            throw new NoUserWithSuchId(ErrorMessages.NoUser);
        var pizza =  user.Orders.FirstOrDefault(x => x.Pizzas.Any(x => x.Id == model.PizzaId && !x.IsDeleted));
        if (pizza == null)
            throw new NoSuchPizzaInUsersOrders(ErrorMessages.NoPizzaInUserOrders);

        await _db.RankHistories.AddAsync(model);
        await _db.SaveChangesAsync();

    }

    public async Task<RankHistoryM> Get(int id)
    {
        return await _db.RankHistories.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<RankHistoryM>> GetAll()
    {
        return await _db.RankHistories.ToListAsync();
    }

    public Task Update(RankHistoryM model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}
