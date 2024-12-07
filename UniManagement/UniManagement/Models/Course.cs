namespace UniManagement.Models;

public class Course:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Schedule { get; set; }
    public int GoneLimit { get; set; }
    public string? TeacherId { get; set; }
    public AppUser? Teacher { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Material> Materials { get; set; }
}


