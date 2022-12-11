using HotelOtomation.Domain.Entities;
using HotelOtomation.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelOtomation.UI.Controllers.UI
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                var role = await _userManager.AddToRoleAsync(user, "Member");
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
