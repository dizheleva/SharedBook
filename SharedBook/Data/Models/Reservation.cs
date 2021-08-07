namespace SharedBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
