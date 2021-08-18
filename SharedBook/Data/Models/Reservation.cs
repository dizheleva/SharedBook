namespace SharedBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Reservation
    {
        [Key] 
        public int Id { get; init; } 

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        public Borrower Sender { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        public User Receiver { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int? SharingDuration { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
    }
}
