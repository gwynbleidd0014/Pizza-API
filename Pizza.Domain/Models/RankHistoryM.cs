using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Domain.Models;

public class RankHistoryM : IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Pizza")]
    public int PizzaId { get; set; }
    public UserM User { get; set; }
    public PizzaM Pizza { get; set; }
    public int Rank { get; set; }
}
