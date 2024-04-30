namespace PizzaSM.Application.Services.Pizza;

public class PizzaResponseModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public double CaloryCount { get; set; }
    public double AverageRank { get; set; }

}
