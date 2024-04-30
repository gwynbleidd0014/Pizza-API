namespace Pizza.Application.Services.RankHistory;

public class RankHistoryRequestModel
{
    public string UserId { get; set; }
    public string PizzaId { get; set; }
    public int Rank { get; set; }
}
