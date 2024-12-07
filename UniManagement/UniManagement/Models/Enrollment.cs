namespace UniManagement.Models;

public class Enrollment:BaseEntity
{
    public AppUser? Student{get;set;}
    public string? StudentId { get; set; }
    public Course? Course { get; set; }
    public int? CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
}