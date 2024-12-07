using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniManagement.Areas.Student.ViewModels;
using UniManagement.DAL;
using UniManagement.Models;

namespace UniManagement.Areas.Student.Controllers;

[Area("Student")]
[Authorize(Roles = "Student")]

public class StudentController(AppDbContext _context,UserManager<AppUser> _userManager):Controller
{   
    private bool isAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;

    public async Task<IActionResult> ShowInfo()
    {
        if (!isAuthenticated) return RedirectToAction("Index", "Home");
        StudentVM student = new StudentVM();
        string? userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        
        var userGrade = await _context.Grades.Where(x => x.StudentId.Equals(userId)).ToListAsync();
        student.Enrollments = await _context.Enrollments.Include(n => n.Student)
            .Where(n => n.StudentId == userId).ToListAsync();

        student.Courses = student.Enrollments.Select(n => n.Course).ToList();
        student.Grades = userGrade;
        return View(student);

    }
    
     [HttpGet]
    public async Task<IActionResult> Update()
    {
        string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

        var user = await _context.AppUsers.FindAsync(userId);
        StudentVM newStudent = new()
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email
        };
        return View(newStudent);
    }

    [HttpPost]
    public async Task<ActionResult> Update(StudentUpdateVM newStudent)
    {
        string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        var user = await _context.AppUsers.FindAsync(userId);
        user.Name = newStudent.Name;
        user.Surname = newStudent.Surname;
        user.Email = newStudent.Email; 
        await  _userManager.ChangePasswordAsync(user,user.PasswordHash,newStudent.Password);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
}
