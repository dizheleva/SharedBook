namespace SharedBook.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Api.Books;
    using Services.Books;

    [Route("api/books")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly IBookService books;

        public BooksApiController(IBookService books) => this.books = books;

        [HttpGet]
        public BookQueryServiceModel GetAllBooks([FromQuery] AllBooksApiRequestModel query) 
            => this.books.All(
                query.Location,
                query.Genre,
                query.SearchTerm, 
                query.Status, 
                query.Sorting,
                query.CurrentPage,
                query.BooksPerPage);
    }
}
