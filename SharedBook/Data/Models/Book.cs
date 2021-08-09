namespace SharedBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static DataConstants;

    public class Book
    {
        [Key] 
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public BookStatus Status { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<BookSharing> Shares { get; init; } = new List<BookSharing>();

        public ICollection<Reservation> Reservations { get; init; } = new List<Reservation>();
    }
}
