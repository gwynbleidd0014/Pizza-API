using Microsoft.EntityFrameworkCore;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Infrastructure.Repositories;

public class PizzaRepository : IRepository<PizzaM>
{
    private readonly ApplicationDbContext _db;

    public PizzaRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(PizzaM model)
    {
        await _db.Pizzas.AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var pizza = await _db.Pizzas.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (pizza is null )
            throw new ResourceNotFound(ErrorMessages.NotFound);

        pizza.IsDeleted = true;
        await _db.SaveChangesAsync();
    }

    public async Task<PizzaM> Get(int id)
    {
        var pizza = await _db.Pizzas.Include("Orders").SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        pizza.AverageRank =  _db.RankHistories.Where(x => x.PizzaId == pizza.Id).Average(x => x.Rank);
        return pizza;
    }

    public async Task<List<PizzaM>> GetAll()
    {
        var pizzas =  await _db.Pizzas.Include("Orders").Where( x => !x.IsDeleted).ToListAsync();
        foreach (var p in pizzas)
        {
            var ranks = await _db.RankHistories.Where(x => x.PizzaId == p.Id).ToListAsync();
            p.AverageRank = ranks.Count > 0 ? ranks.Average(x => x.Rank) : 0;
        }
        return pizzas;
    }

    public async Task Update(PizzaM model)
    {
        var oldModel = await _db.Pizzas.SingleOrDefaultAsync(x => x.Id == model.Id && !x.IsDeleted);
        RepositoryUtility<PizzaM>.UpdateProperties(oldModel, model);
        await _db.SaveChangesAsync();
    }
}
