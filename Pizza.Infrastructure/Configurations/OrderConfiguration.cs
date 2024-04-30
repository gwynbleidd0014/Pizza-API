using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Models;


namespace Pizza.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderM>
{
    public void Configure(EntityTypeBuilder<OrderM> builder)
    {
     builder.HasMany(x => x.Pizzas)
    .WithMany(y => y.Orders)
    .UsingEntity(j => j.ToTable("PizzaOrder"));
    }
}
