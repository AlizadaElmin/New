namespace UniManagement.Models;


public class Grade:BaseEntity
{
    public AppUser? Student { get; set; }
    public string? StudentId { get; set; }
    public double StudentGrade { get; set; }
    public DateTime EvaluatedAt { get; set; }
    public Task? Task { get; set; }
    public int? TaskId { get; set; }

}
