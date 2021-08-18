namespace SharedBook.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Reservation
    {
        [Key] 
        public int Id { get; init; } 

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public User Receiver { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int? SharingDuration { get; set; }

        [Required]
        public ReservationStatus ReservationStatus { get; set; }
    }
}
