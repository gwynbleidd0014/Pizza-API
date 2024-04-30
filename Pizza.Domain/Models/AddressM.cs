using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Domain.Models;

public class AddressM : IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Description { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserM User { get; set; }
    public List<OrderM> Orders { get; set; }
}
