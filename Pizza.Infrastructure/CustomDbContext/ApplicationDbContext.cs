using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pizza.Domain.Models;
using Pizza.Persistence;
namespace Pizza.Infrastructure.CustomDbContext;

public class ApplicationDbContext : DbContext
{
    private readonly IOptions<ConnectionStrings> _opts;
    public ApplicationDbContext(IOptions<ConnectionStrings> opts)
    {
        _opts = opts;
    }

    public DbSet<PizzaM> Pizzas { get; set; }
    public DbSet<UserM> Users { get; set; }
    public DbSet<AddressM>  Addresses { get; set; }
    public DbSet<OrderM> Orders { get; set; }
    public DbSet<RankHistoryM> RankHistories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_opts.Value.DefaultConnection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaM>().HasData(
            new PizzaM()
            {
                Id = 1,
                Name = "Margarita",
                IsDeleted = false,
                Description = "Margarita Pizza made With love Custom Covering",
                CaloryCount = 45.5,
                Price = 20.2m
            }
            );
        modelBuilder.Entity<PizzaM>().Property(x => x.Price).HasPrecision(10, 5);
        modelBuilder.Entity<OrderM>().HasMany(x => x.Pizzas)
            .WithMany(y => y.Orders)
            .UsingEntity(j => j.ToTable("PizzaOrder"));
        
    }
}
