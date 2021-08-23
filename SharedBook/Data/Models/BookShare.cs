namespace SharedBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookShare
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public DateTime CreationDate { get; init; }

        [Required]
        public DateTime? DueDate { get; init; }

        [Required]
        public DateTime? ReturnDate { get; set; }

        [Required] 
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("UserId")]
        public User Owner { get; set; }

        [Required]
        public string BorrowerId { get; set; }

        [ForeignKey("BorrowerId")]
        public User Borrower { get; set; }
    }
}
