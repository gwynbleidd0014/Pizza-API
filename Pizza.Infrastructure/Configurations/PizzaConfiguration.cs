using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Models;
using System.Reflection.Emit;

namespace Pizza.Infrastructure.Configurations;

public class PizzaConfiguration : IEntityTypeConfiguration<PizzaM>
{
    public void Configure(EntityTypeBuilder<PizzaM> builder)
    {
        builder.Property(x => x.Price).HasPrecision(10, 5);
    }
}
