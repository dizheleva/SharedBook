namespace SharedBook.Controllers
{
    using Data;
    using Data.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Borrower;
    using Services.Books;

    public class BorrowersController : Controller
    {
        private readonly SharedBookDbContext data;

        public BorrowersController(SharedBookDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeBorrowerFormModel borrowerForm)
        {
            if (!ModelState.IsValid)
            {
                return View(borrowerForm);
            }

            var newBorrower = new Borrower
            {
                UserId = this.User.GetId(),
                Deposit = 0.0m
            };

            this.data.Borrowers.Add(newBorrower);

            return RedirectToAction("All", "Books");
        }
    }
}
