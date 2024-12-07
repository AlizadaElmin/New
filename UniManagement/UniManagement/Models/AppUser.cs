using Microsoft.AspNetCore.Identity;
using UniManagement.Utilities;

namespace UniManagement.Models;

public class AppUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

