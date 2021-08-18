namespace SharedBook.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Books;

    public class UsersController : AdminController
    {
        private readonly IBookService books;
        private readonly SharedBookDbContext data;

        public UsersController(IBookService books, SharedBookDbContext data)
        {
            this.books = books;
            this.data = data;
        }

        public IActionResult List()
        {
            if (!data.Users.Any())
            {
                return View("Empty");
            }

            List<MemberViewModel> usersList = new List<MemberViewModel>();

            var users = data.Users;

            foreach (var user in users)
            {
                usersList.Add(new MemberViewModel
                {
                    Member = user
                });
            }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            this.data.Users.Add(user);
            this.data.SaveChanges();

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
