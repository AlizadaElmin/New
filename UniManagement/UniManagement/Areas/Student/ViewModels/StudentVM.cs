using UniManagement.Models;

namespace UniManagement.Areas.Student.ViewModels;

public class StudentVM
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public List<Grade> Grades { get; set; }
    public List<Course> Courses { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}