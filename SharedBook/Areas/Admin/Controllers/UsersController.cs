namespace SharedBook.Areas.Admin.Controllers
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class UsersController : AdminController
    {
        private readonly SharedBookDbContext data;

        public UsersController(SharedBookDbContext data)
        {
            this.data = data;
        }

        public IActionResult List()
        {
            var users = data.Users;

            var usersList = users.Select(user => new MemberViewModel { Member = user }).ToList();

            return View(usersList);
        }

        public IActionResult Update(string id)
        {
            var user = this.data.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            this.data.Users.Update(user);

            return RedirectToAction("List");
        }

        public IActionResult Block(string id)
        {
            var user = this.data.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserStatus = UserStatus.Blacklisted;

            return RedirectToAction("List");
        }
    }
}
