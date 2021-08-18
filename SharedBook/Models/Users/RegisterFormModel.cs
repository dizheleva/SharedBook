namespace SharedBook.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        public string RepeatPassword { get; set; }

        [Required]
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserNamesMinLength)]
        [MaxLength(UserNamesMaxLength)]
        public string LastName { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
