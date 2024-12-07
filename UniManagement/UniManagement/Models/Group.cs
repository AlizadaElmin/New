namespace UniManagement.Models;

public class Group:BaseEntity
{
    public string Name { get; set; }
    public ICollection<AppUser>? Students { get; set; }
}