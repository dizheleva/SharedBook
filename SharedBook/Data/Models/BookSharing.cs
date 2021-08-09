namespace SharedBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookSharing
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime? ReturnDate { get; set; }

        [Required] 
        public string BookId { get; set; }

        public Book Book { get; set; }

        [Required] 
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
