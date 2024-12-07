using System.ComponentModel.DataAnnotations;

namespace UniManagement.Areas.Student.ViewModels;

public class StudentUpdateVM
{
    [MaxLength(16)]
    public string Name { get; set; }
    [MaxLength(32)]
    public string Surname { get; set; }
    [MaxLength(128)]
    public string Email { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}