namespace SharedBook.Data.Models
{
    using Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StatusId { get; set; }

        public RequestStatus Status { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public int SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
