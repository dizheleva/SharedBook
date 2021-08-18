namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class Borrower
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public decimal Deposit { get; set; }

        public ICollection<Book> WishList { get; set; } = new List<Book>();

        public ICollection<BookShare> BorrowedBooks { get; set; } = new List<BookShare>();

        public ICollection<Reservation> SentReservationRequests { get; set; } = new List<Reservation>();
    }
}
