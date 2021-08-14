namespace SharedBook.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalBooks { get; init; }

        public int TotalUsers { get; init; }

        public int TotalShares { get; init; }

        public IEnumerable<BookIndexViewModel> Books { get; init; } = new List<BookIndexViewModel>();
    }
}
