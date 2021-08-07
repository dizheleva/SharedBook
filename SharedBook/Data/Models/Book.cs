namespace SharedBook.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Book
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public BookStatus Status { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public User User { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
