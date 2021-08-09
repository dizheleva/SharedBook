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
        public string BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public User Receiver { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
    }
}
