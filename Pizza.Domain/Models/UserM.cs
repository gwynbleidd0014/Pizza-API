namespace Pizza.Domain.Models;

public class UserM : IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<AddressM> Address { get; set; }
    public List<OrderM> Orders { get; set; }
    public List<RankHistoryM> RankHistories { get; set; }

}
