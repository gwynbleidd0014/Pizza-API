using Microsoft.EntityFrameworkCore;
using Pizza.Application.Exceptions;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Infrastructure.Repositories;

public class OrderRepository : IRepository<OrderM>
{
    private readonly ApplicationDbContext _db;

    public OrderRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(OrderM model)
    {
        var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == model.UserId && !x.IsDeleted);
        if (user is null)
            throw new NoUserWithSuchId(ErrorMessages.NoUser);

        var address = await _db.Addresses.SingleOrDefaultAsync(x => x.Id == model.AddressId && x.UserId == user.Id && !x.IsDeleted);
        
        if (address is null)
            throw new NoAddressWithSuchId(ErrorMessages.NoAddress);
        if (model.Pizzas.Count == 0 || await CheckPizzaIds(model.Pizzas))
            throw new NoPizzaWithSuchId(ErrorMessages.NoPizza);

        await _db.AddAsync(model);
        await _db.SaveChangesAsync();
    }


    public async Task<OrderM> Get(int id)
    {  
        return await _db.Orders.Include("Pizzas").SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<List<OrderM>> GetAll()
    {
        return await _db.Orders.Include("Pizzas").Where(x => !x.IsDeleted).ToListAsync();
    }

    async Task<bool> CheckPizzaIds(List<PizzaM> pizzas)
    {
        for (int i = 0; i < pizzas.Count; i++)
        {
            var fullPizza = await _db.Pizzas.SingleOrDefaultAsync(x => x.Id == pizzas[i].Id);
            if (fullPizza == null)
                return true;

            pizzas[i] = fullPizza; 
        }

        return false;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderM model)
    {
        throw new NotImplementedException();
    }
}
