using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Domain.Models;

public class PizzaM : IEntity
{
    [MaxLength(100)]
    [MinLength(1)]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public double CaloryCount { get; set; }
    public bool IsDeleted { get; set; }
    public List<OrderM> Orders { get; set; }
    public List<RankHistoryM> RankHistories { get; set; }
    [NotMapped]
    public double AverageRank { get; set; }
}
