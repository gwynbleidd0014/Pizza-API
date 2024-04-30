using Microsoft.EntityFrameworkCore;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Infrastructure.Repositories;

public class UserRepository : IRepository<UserM>
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(UserM model)
    {
        await _db.AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (user is null)
            throw new ResourceNotFound(ErrorMessages.NotFound);
        var addreses = _db.Addresses.Where(x => x.UserId == user.Id && !x.IsDeleted);
        var orders = _db.Orders.Where(x => x.UserId == user.Id && !x.IsDeleted);

        foreach (var addres in addreses)
        {
            addres.IsDeleted = true;
        }

        user.IsDeleted = true;
        await _db.SaveChangesAsync();
    }

    public async Task<UserM> Get(int id)
    {
        var user = await _db.Users
            .Include(u => u.Orders)
            .Include(u => u.Address.Where(x => !x.IsDeleted))
            .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        return await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<List<UserM>> GetAll()
    {
        var users = await _db.Users
            .Where(x => !x.IsDeleted)
            .Include(u => u.Orders)
            .Include(u => u.Address.Where(x => !x.IsDeleted))
            .ToListAsync();

        return users;
    }

    public async Task Update(UserM model)
    {
        var oldModel = await _db.Users.SingleOrDefaultAsync(x => x.Id == model.Id && !x.IsDeleted);
        RepositoryUtility<UserM>.UpdateProperties(oldModel, model);
        await _db.SaveChangesAsync();
    }
}
