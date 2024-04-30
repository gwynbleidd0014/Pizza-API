using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Domain.Models;
using Pizza.Infrastructure.CustomDbContext;

namespace Pizza.Infrastructure.Seed;

static class SeedInitialData
{
    public static void LazyInitializer(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContex = scope.ServiceProvider.GetService<ApplicationDbContext>();
        Migrate(dbContex);
        SeedEverything(dbContex);
    }

    private static void Migrate(ApplicationDbContext dbContex)
    {
        dbContex.Database.Migrate();
    }

    private static void SeedEverything(ApplicationDbContext dbContext)
    {
        var seeded = false;
        SeedPizza(dbContext, ref seeded);
        
    }

    private static void SeedPizza(ApplicationDbContext dbContext, ref bool seeded)
    {
        var pizzas = new List<PizzaM>()
        {
            new PizzaM()
            {
                Id = 1,
                Name = "Margarita",
                IsDeleted = false,
                Description = "Margarita Pizza made With love Custom Covering",
                CaloryCount = 45.5,
                Price = 20.2m
            }
        };

        foreach (var pizza in pizzas)
        {
            if (dbContext.Pizzas.Any(x => x.Id == pizza.Id)) 
                continue;
            dbContext.Pizzas.Add(pizza);
            seeded = true;
        }
    }
}
