namespace SharedBook.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;
    using Microsoft.AspNetCore.Identity;
    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string LastName { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        
        [Required]
        [MaxLength(PhoneMaxLength)]
        [RegularExpression(@"/08[789]\d{7}/")]
        public string Phone { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public UserStatus UserStatus { get; set; }

        public ICollection<Book> OwnedBooks { get; set; } = new List<Book>();

        public ICollection<Reservation> ReceivedReservationRequests { get; set; } = new List<Reservation>();

        public ICollection<BookShare> SharedBooks { get; set; } = new List<BookShare>();
    }
}