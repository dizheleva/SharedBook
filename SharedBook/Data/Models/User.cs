namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public string ProfilePicture { get; set; }

        public ICollection<Book> OwnedBooks { get; init; } = new List<Book>();

        public ICollection<BookSharing> BorrowedBooks { get; init; } = new List<BookSharing>();

        public ICollection<Reservation> Reservations { get; init; } = new List<Reservation>();

        public ICollection<Request> SentRequests { get; init; } = new List<Request>();

        public ICollection<Request> ReceivedRequests { get; init; } = new List<Request>();
    }
}