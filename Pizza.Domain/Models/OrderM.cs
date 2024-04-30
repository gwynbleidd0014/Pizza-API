using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Domain.Models
{
    public class OrderM : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public UserM User { get; set; }
        public AddressM Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<PizzaM> Pizzas { get; set; }
    }
}
