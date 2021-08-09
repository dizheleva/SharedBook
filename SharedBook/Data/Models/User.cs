namespace SharedBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static DataConstants;

    public class User
    {
        [Key] 
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"/08[789]\d{7}/")]
        public string Phone { get; set; }

        [Required]
        public UserStatus UserStatus { get; set; }

        //public string ProfilePicture { get; set; }

        public ICollection<Book> OwnedBooks { get; set; } = new List<Book>();

        public ICollection<BookSharing> BorrowedBooks { get; set; } = new List<BookSharing>();

        public ICollection<Reservation> SentReservationRequests { get; set; } = new List<Reservation>();

        public ICollection<Reservation> ReceivedReservationRequests { get; set; } = new List<Reservation>();
    }
}