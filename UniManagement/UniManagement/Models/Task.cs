namespace UniManagement.Models;

public class Task:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public double MaxGradePoint { get; set; }
    public DateTime Deadline { get; set; }
    public Material? Material { get; set; }
    public int? MaterialId { get; set; }
    public ICollection<Grade> Grades { get; set; }
}


