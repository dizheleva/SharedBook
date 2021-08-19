namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using Microsoft.AspNetCore.Identity;
    using static DataConstants;

    public class User : IdentityUser
    {
        
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string FirstName { get; set; }
        
       
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string LastName { get; set; }

        
        public int? AddressId { get; set; }

        
        public Address Address { get; set; }

        [Required]
        public UserStatus UserStatus { get; set; }

        public ICollection<Book> OwnedBooks { get; set; } = new List<Book>();

        public ICollection<Reservation> ReceivedReservationRequests { get; set; } = new List<Reservation>();

        public ICollection<BookShare> SharedBooks { get; set; } = new List<BookShare>();

        public ICollection<Book> WishList { get; set; } = new List<Book>();

        public ICollection<BookShare> BorrowedBooks { get; set; } = new List<BookShare>();

        public ICollection<Reservation> SentReservationRequests { get; set; } = new List<Reservation>();
    }
}