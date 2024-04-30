namespace Pizza.Domain.Models;
public interface IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}
