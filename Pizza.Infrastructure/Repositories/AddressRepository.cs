using Microsoft.EntityFrameworkCore;
using Pizza.Application.Localization;
using Pizza.Application.Services.Exceptions;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;
using PizzaSM.Application.Services.Repositories;

namespace Pizza.Infrastructure.Repositories;

public class AddressRepository : IRepository<AddressM>
{
    private readonly ApplicationDbContext _db;

    public AddressRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(AddressM model)
    {
        if (await _db.Users.SingleOrDefaultAsync(x => x.Id == model.UserId && !x.IsDeleted) is null)
        {
            throw new NoUserWithSuchId(ErrorMessages.NoUser);
        }
        await _db.Addresses.AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var adress = await _db.Addresses.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (adress is null)
            throw new ResourceNotFound(ErrorMessages.NotFound);

        adress.IsDeleted = true;
        await _db.SaveChangesAsync();
    }

    public async Task<AddressM> Get(int id)
    {
        return await _db.Addresses.Include("Orders").SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<List<AddressM>> GetAll()
    {
        return await _db.Addresses.Include("Orders").Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task Update(AddressM model)
    {
        var oldModel = await _db.Addresses.SingleOrDefaultAsync(x => x.Id == model.Id && !x.IsDeleted);
        RepositoryUtility<AddressM>.UpdateProperties(oldModel, model);
        await _db.SaveChangesAsync();
    }
}
