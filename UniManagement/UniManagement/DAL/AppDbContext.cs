using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniManagement.Models;
using Task = UniManagement.Models.Task;

namespace UniManagement.DAL;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Grade> Grades { get; set; }


}
