namespace SharedBook.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;

    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var registeredUser = new User
            {
                Email = user.Email,
                UserStatus = UserStatus.Active
            };

            var result = await this.userManager.CreateAsync(registeredUser, user.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(BooksController.All), "Books");
            }

            var errors = result.Errors.Select(e => e.Description);

            foreach (var error in errors)
            {
                ModelState.AddModelError(String.Empty, error);
            }

            return View(user);

        }
    }
}
