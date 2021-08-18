namespace SharedBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;
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
        [EnumDataType(typeof(Genre))]
        public Genre? Genre { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        
        [Required]
        public City Location { get; set; }

        [Required]
        [EnumDataType(typeof(BookStatus))]
        public BookStatus Status { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        public ICollection<BookShare> Shares { get; set; } = new List<BookShare>();

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
