using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UniManagement.DAL;
using UniManagement.Models;
using UniManagement.Utilities;

namespace UniManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly AppDbContext _db;

        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;


        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> SeedData()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Tutor.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole("Tutor"));
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Teacher.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole("Teacher"));
            }
            
            if (!await _roleManager.RoleExistsAsync(Roles.Student.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }

            if(!await _userManager.Users.AnyAsync(u => u.NormalizedUserName == "TUTOR"))
            {
                AppUser tutor = new AppUser()
                {
                    Name = "Tutor",
                    Surname = "Tutor",
                    UserName = "Tutor",
                    Email = "tutor@admin.com"
                };
                await _userManager.CreateAsync(tutor, "tutor123");
                await _userManager.AddToRoleAsync(tutor, Roles.Tutor.ToString());
            }

            return default;
        }

        
    }
}
