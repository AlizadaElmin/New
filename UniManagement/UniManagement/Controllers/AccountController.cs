using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniManagement.Models;

namespace UniManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: AccountController
        //public IActionResult Register() => View(new RegisterVM());

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterVM registerVM)
        //{
        //    // Check if Name and Surname contain numbers
        //    if (registerVM.Name.Any(char.IsDigit) || registerVM.Surname.Any(char.IsDigit))
        //    {
        //        ModelState.AddModelError("Name", "Name and surname cannot contain numbers.");
        //    }

        //    if (!ModelState.IsValid)
        //        return View(registerVM);

        //    // Normalize the user input
        //    var normalizedUserName = registerVM.UserName.ToLowerInvariant();
        //    var normalizedEmail = registerVM.Email.ToLowerInvariant();

        //    // Check if a user with the same username or email already exists
        //    var existingUser = await _userManager.Users
        //        .FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName || u.NormalizedEmail == normalizedEmail);

        //    if (existingUser != null)
        //    {
        //        if (existingUser.NormalizedUserName == normalizedUserName)
        //        {
        //            ModelState.AddModelError("UserName", "This username is already taken.");
        //        }
        //        if (existingUser.NormalizedEmail == normalizedEmail)
        //        {
        //            ModelState.AddModelError("Email", "This email is already taken.");
        //        }
        //        return View(registerVM);
        //    }

        //    // Create a new user with normalized values
        //    var user = new AppUser
        //    {
        //        Name = registerVM.Name,
        //        Surname = registerVM.Surname,
        //        UserName = normalizedUserName, // Store username in lowercase
        //        Email = normalizedEmail,       // Store email in lowercase
        //    };

        //    // Create the user
        //    var result = await _userManager.CreateAsync(user, registerVM.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //            ModelState.AddModelError("", error.Description);

        //        return View(registerVM);
        //    }

        //    // Generate email confirmation token
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var confirmationLink = Url.Action(
        //        nameof(ConfirmEmail),
        //        "Account",
        //        new { token, email = user.Email },
        //        Request.Scheme);

        //    // Prepare email body
        //    var body = $@"
        //        <h1>Welcome to Our Team</h1>
        //        <p>Thank you for registering with us. Please confirm your email by clicking the link below:</p>
        //        <a href='{confirmationLink}'>Confirm Email</a>";

        //    // Send email
        //    await _emailService.SendMailAsync(user.Email, "Email Confirmation", body, true);

        //    // Assign role to user
        //    await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());

        //    // Redirect to the registration success page
        //    return RedirectToAction(nameof(SuccessfullyRegistered));
        //}

    }
}

